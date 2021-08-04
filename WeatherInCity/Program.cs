using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WeatherInCity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите город: ");
            string nameCity= Console.ReadLine();

            string URL = "http://api.openweathermap.org/data/2.5/weather?q="+ nameCity + "&units=metric&appid=f512d90c89c076d365eaa2e7752736a3";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse httpWebResponce = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponce.GetResponseStream())) 
            {
                response = streamReader.ReadToEnd(); 
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            
            int zoneID = weatherResponse.Timezone;  
            DateTime Sunrise = DateTimeOffset.FromUnixTimeSeconds(weatherResponse.Sys.Sunrise+zoneID).DateTime;  // конвертирование unix time to datetime прибавляем код у timezone, которая содержит разницу времени
            DateTime Sunset = DateTimeOffset.FromUnixTimeSeconds(weatherResponse.Sys.Sunset+zoneID).DateTime;


            File.WriteAllText("weather in "+ nameCity + ".txt", "Temperature in " + weatherResponse.Name + ": " + weatherResponse.Main.Temp + " °C\n");
            File.AppendAllText("weather in " + nameCity + ".txt", "Humidity in " + weatherResponse.Name +":"+ weatherResponse.Main.Humidity + "%\n");   
            File.AppendAllText("weather in " + nameCity + ".txt", "Sunrise : " + Sunrise + ";  Sunset : " + Sunset );


            Console.WriteLine("Temperature in {0}: {1} °C", weatherResponse.Name, weatherResponse.Main.Temp);
            Console.WriteLine("Humidity in {0}: {1} %", weatherResponse.Name, weatherResponse.Main.Humidity);           
            Console.WriteLine("Sunrise in {0}; Sunset {1} ", Sunrise, Sunset);


            Console.Write("Нажмите любую клавишу для выхода..."+zoneID);
            Console.ReadKey();
        }
    }
}
