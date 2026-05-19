using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using DotNetEnv;
using System.Net.Http;
using System.Text;
using System.Text.Json;


namespace F1_Manager_2026.Artificial_Inteligence
{
    internal class test
    {
        public async void doSomething()
        {
            var db = Database.Instance;
           string prompt = $@"Tell me something about Siemens and their racing history.";


            Env.Load();

            string apiKey = Environment.GetEnvironmentVariable("Groq");

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var body = new
            {
                model = "llama-3.3-70b-versatile",
                messages = new[]
                {
        new
        {
            role = "user",
            content = prompt
        }
    }
            };

            string json = JsonSerializer.Serialize(body);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(
                "https://api.groq.com/openai/v1/chat/completions",
                content
            );

            string responseString = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(responseString);
string aiResponse  = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            MessageBox.Show(aiResponse);

        }

    }
}
