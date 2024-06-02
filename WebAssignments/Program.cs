using System;
using System.Net;
using System.Text;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:5226/time/");
        listener.Start();
        Console.WriteLine("Listening requests on http://localhost:5226/time/");

        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;

            if (request.HttpMethod == "POST")
            {
                using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string timeZoneId = reader.ReadToEnd();

                    try
                    {
                        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                        DateTime currentTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone);
                        string responseString = $"Текущее время в часовом поясе {timeZoneId}: {currentTime}";

                        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                        context.Response.ContentLength64 = buffer.Length;
                        context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                    catch (TimeZoneNotFoundException)
                    {
                        string responseString = "Неверный идентификатор часового пояса.";
                        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        context.Response.ContentLength64 = buffer.Length;
                        context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }

            context.Response.OutputStream.Close();
        }
    }
}
