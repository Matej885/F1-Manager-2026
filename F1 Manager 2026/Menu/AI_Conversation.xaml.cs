using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using DotNetEnv;

namespace F1_Manager_2026.Menu
{
    public partial class AI_Conversation : Window
    {
        // ObservableCollection allows the UI to update automatically when messages are added
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();

        public AI_Conversation()
        {
            InitializeComponent();
            ChatItemsControl.ItemsSource = Messages;
            Env.Load();
        }

        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            string userText = UserInput.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

            // Add user message to UI
            Messages.Add(new ChatMessage { Sender = "TEAM PRINCIPAL", Message = userText, Alignment = HorizontalAlignment.Right, BackgroundColor = "#1A1A1A" });
            UserInput.Clear();
            ChatScrollViewer.ScrollToEnd();

            try
            {
                string apiKey = Environment.GetEnvironmentVariable("Groq");
                using HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                var body = new
                {
                    model = "llama-3.3-70b-versatile",
                    messages = new[] { new { role = "user", content = userText } }
                };

                string json = JsonSerializer.Serialize(body);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    using JsonDocument doc = JsonDocument.Parse(responseString);
                    string aiResponse = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();

                    // Add AI response to UI
                    Messages.Add(new ChatMessage { Sender = "AI ADVISOR", Message = aiResponse, Alignment = HorizontalAlignment.Left, BackgroundColor = "#051505" });
                }
                else
                {
                    Messages.Add(new ChatMessage { Sender = "SYSTEM", Message = "Connection Error: Failed to reach Groq systems.", Alignment = HorizontalAlignment.Center, BackgroundColor = "#330000" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Critical Error: {ex.Message}");
            }

            ChatScrollViewer.ScrollToEnd();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Send_Click(null, null);
        }

        private void Back_Click(object sender, RoutedEventArgs e) => this.Close();
    }

    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public HorizontalAlignment Alignment { get; set; }
        public string BackgroundColor { get; set; }
    }
}