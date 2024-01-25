using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string apiUrl = "https://api.umov.me/CenterWeb/api/{apiKey}/schedule.xml";

        string apiKey = "39272ed6848483aec12eb2d7de48aaa2132681";

        string requestUrl = apiUrl.Replace("{apiKey}", apiKey);

        string xmlRequestBody = @"
            <schedule>
                <agent>
                    <id>10</id>
                </agent>
                <serviceLocal>
                    <id>12345</id>
                </serviceLocal>
                <activitiesOrigin>4</activitiesOrigin>
                <date>2024-11-01</date>
                <hour>08:00</hour>
                <activityRelationship>
                    <activity>
                        <alternativeIdentifier>identifier***</alternativeIdentifier>
                    </activity>
                    <activity>
                        <alternativeIdentifier>identifier***</alternativeIdentifier>
                    </activity>
                </activityRelationship>
                <customFields>
                    <Nro_OS>9854</Nro_OS>
                    <Contato>Fulano de tal</Contato>
                </customFields>
                <scheduleType>
                    <alternativeIdentifier>identifier***</alternativeIdentifier>
                </scheduleType>
            </schedule>";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                var content = new StringContent(xmlRequestBody, System.Text.Encoding.UTF8, "application/xml");

                HttpResponseMessage response = await client.PostAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("sucesso 200");
                }
                else
                {
                    Console.WriteLine($"Erro na retuisicao: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
