using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    internal class Getdata
    {
        string text;
        public Getdata() { this.text = "AMZN, 120\r\nMSFT, 300\r\nGOOG, 20\r\nMSFT, 200\r\nINTL, 250\r\nAMZN, 110"; }

        
        public string ReadStringFromFile()
        {
            string filePath = "C:\\Users\\eugeniu.negru\\Desktop\\text.txt";
            string content = string.Empty;

            try
            {
                content = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return content;
        }
        public async Task<string> ReadContentFromHttp()
        {
            string content = string.Empty;
            string url = "https://functionapp120230308230339.azurewebsites.net/api/Function2?code=ywph30tshmqEXJkFOdYy5LRT--7BUtejKBpOb97F00wjAzFuyfCtcQ==";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    content = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return content;
        }
        public string Text
        {
            get { return text; }
        }

    }
}
