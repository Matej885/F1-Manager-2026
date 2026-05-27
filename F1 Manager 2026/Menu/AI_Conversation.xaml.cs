using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using DotNetEnv;
using F1_Manager_2026.Picking_Team;

namespace F1_Manager_2026.Menu
{
    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public HorizontalAlignment Alignment { get; set; }
        public string BackgroundColor { get; set; }
        public string SenderColor { get; set; }
        public string ProfileImage { get; set; }
        public Visibility ImageVisibility { get; set; }
    }

    public partial class AI_Conversation : Window
    {
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();
        private readonly HttpClient client = new HttpClient();

        public AI_Conversation()
        {
            InitializeComponent();
            ChatItemsControl.ItemsSource = Messages;
            Env.Load();

            var db = Database.Instance;
            if (db.CurrentDayInfo.EndOfSeason)
            {
                TriggerInitialGreeting();
            }
        }

        private async void TriggerInitialGreeting()
        {
            // Šéf tímu (AI) začne konverzáciu sám
            await SendRequestToAI("The season is over. I am waiting for your report. Don´t forget to say hello also");
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            string userText = UserInput.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

            // TY SI: TEAM MANAGER (Používateľ pôjde vpravo)
            AddMessage("TEAM MANAGER", userText, HorizontalAlignment.Right, "#1A1A1A");
            UserInput.Clear();

            await SendRequestToAI(userText);
        }

        private async System.Threading.Tasks.Task SendRequestToAI(string userText)
        {
            try
            {
                string apiKey = Environment.GetEnvironmentVariable("Groq");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var db = Database.Instance;
                var apiMessages = new List<object>();

                // 1. SYSTEM PROMPT (Upravené na Team Principal / Team Manager vzťah)
                apiMessages.Add(new
                {
                    role = "system",
                    content = $@"You are an experienced Formula 1 Team Principal conducting an end-of-season review with your Team Manager. Tone: Professional, realistic and conversational. Calm authority instead of aggressive hostility. Speak naturally like a real private team meeting or WhatsApp-style conversation. Keep messages relatively short and dynamic. No emojis. Stay fully in character. Behavior Rules: 1. Start the conversation naturally with a season review. 2. Allow a realistic back-and-forth conversation. 3. Do not instantly end the conversation after 2-3 replies. 4. Usually keep the discussion between 4-10 messages total unless the conversation naturally ends earlier. 5. Do not constantly ask for highly technical details. 6. Focus more on leadership, expectations, results, momentum, drivers, finances, team morale and future plans. 7. If the player massively overachieved the goal, acknowledge it and give genuine praise while remaining professional. 8. If the player slightly missed expectations, be disappointed but fair. 9. If the player completely failed expectations, become more serious and question leadership decisions. 10. Occasionally use realistic F1/business terms like: long-term project, development direction, sponsor confidence, competitiveness, aerodynamic performance, infrastructure, return on investment. But do NOT overuse them. Conversation Flow: Begin naturally. React dynamically to the player's replies. Avoid repeating the same phrases. The conversation should feel human and varied. The Team Principal can soften if the player gives good reasoning. The Team Principal can become stricter if excuses sound weak. Season Context: Final WCC Position: P{db.PlayerTeamInstance.WCCPosition}, Season Goal: P{db.PlayerTeamInstance.SeasonGoal}. Decision Rules: At the end of the conversation, make a final decision. If the player is fired, the FINAL message must contain ONLY: [TERMINATED]. If the player keeps the job, the FINAL message must contain ONLY: [PROCEED]. Important: The final verdict message must contain nothing except [TERMINATED] or [PROCEED]. Do not rush toward the verdict. End the conversation naturally before giving the final verdict. Additional Context: {BuildAIContext()}"
                });

                // 2. OPRAVENÁ HISTÓRIA: Správne priradenie rolí pre Groq API
                foreach (var msg in Messages)
                {
                    // "TEAM MANAGER" (Ty) = user, "TEAM PRINCIPAL" (AI) = assistant
                    string role = (msg.Sender == "TEAM MANAGER") ? "user" : "assistant";
                    apiMessages.Add(new { role = role, content = msg.Message });
                }

                var body = new
                {
                    model = "llama-3.3-70b-versatile",
                    messages = apiMessages
                };

                string json = JsonSerializer.Serialize(body);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(responseString);
                    string aiText = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

                    // AI JE: TEAM PRINCIPAL (Pôjde vľavo s profilovkou)
                    AddMessage("TEAM PRINCIPAL", aiText, HorizontalAlignment.Left, "#0A0A0A");

                    // Kontrola konca hry
                    if (aiText.Contains("[TERMINATED]"))
                    {
                        MessageBox.Show("You have been fired from the team because you didn´t do enough. Better luck next time!", "Career Over");
                        SaveGame.DeleteSave();
                        Options options = new Options();
                        options.Show();
                        this.Close();
                    }
                    else if (aiText.Contains("[PROCEED]") || aiText.Contains("PROCEED"))
                    {
                        MessageBox.Show("Contract extended. Prepare for next season! ", "Success");
                        double realstartermoney = db.PlayerTeamInstance.startermoney * 1.2;
                        db.PlayerTeamInstance.Budget += realstartermoney;
                        Engine_Pick engine_Pick = new Engine_Pick();
                        db.Calendar2026.Clear();
                        db.FillCalendar(db.PlayerTeamInstance.desiredraces);
                        engine_Pick.Show();
                        this.Close();
                    }
                }
                else
                {
                    AddMessage("SYSTEM", "API Error: " + response.StatusCode, HorizontalAlignment.Center, "#330000");
                }
            }
            catch (Exception ex)
            {
                AddMessage("SYSTEM", "Error: " + ex.Message, HorizontalAlignment.Center, "#330000");
            }
        }

        private void AddMessage(string who, string text, HorizontalAlignment side, string color)
        {
            // Šéfom tímu (AI) je teraz TEAM PRINCIPAL
            bool isPrincipal = (who == "TEAM PRINCIPAL");

            Messages.Add(new ChatMessage
            {
                Sender = who,
                Message = text,
                Alignment = side,
                BackgroundColor = color,
                SenderColor = isPrincipal ? "#E10600" : "#AAAAAA",
                ProfileImage = isPrincipal ? "/Images/Boss_Avatar.png" : null,
                ImageVisibility = isPrincipal ? Visibility.Visible : Visibility.Collapsed
            });

            if (ChatScrollViewer != null)
                ChatScrollViewer.ScrollToEnd();
        }

        private string BuildAIContext()
        {
            var db = Database.Instance;
            var team = db.PlayerTeamInstance;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Team: {team.teamName} | Budget: {team.Budget:N0}$ | Prestige: {team.Prestige}");
            sb.AppendLine($"Goal: P{team.SeasonGoal} | Current: P{team.WCCPosition}");
            sb.AppendLine($"Car: Eng:{team.EnginePower} Aero:{team.AeroPower} Cha:{team.ChassisPower}");
            sb.AppendLine("Player Name: " + team.PlayerName);

            var myDrivers = db.DriverList.Where(x => x.Team == team.teamName);
            foreach (var d in myDrivers)
                sb.AppendLine($"Driver: {d.Name} | Pts: {d.Points}");

            return sb.ToString();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Send_Click(null, null);
        }

        private void Back_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}