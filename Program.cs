using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net.Http;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Xaml;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace world
{
    class Program
    {
        static void Main(string[] args)
        {
            //REAd configuration file into string
            string filecontent = ReadConfigurationFile("E:/c#/weatherProgram/world/cities.json");
            //parse filecontent

            CityConfig[] cityConfigArray = new JavaScriptSerializer().Deserialize<CityConfig[]>(filecontent);
            weather weather = new weather();
            

            foreach (CityConfig cityConfig in cityConfigArray)
            {
                Console.WriteLine(cityConfig.city);
              
                float tempkdp = weather.GetCurrentTemperature(cityConfig.city, cityConfig.countrycode);
                Console.WriteLine("temperature :  " + tempkdp);
                //body
                // HttpClient post
                string url = "http://api.openweathermap.org/data/2.5/weather?q=" + cityConfig.city + "," + cityConfig.countrycode + "&APPID=6eb1b56a44171680a7ac1497d62dedb6";
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(filecontent);
               
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/json");

                HttpResponseMessage response = client.PostAsync("http://api.openweathermap.org/data/2.5/weather?q=" + cityConfig.city + "," + cityConfig.countrycode + "&APPID=6eb1b56a44171680a7ac1497d62dedb6", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(CityConfig));
                    
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    CityConfig Response = (CityConfig)json.ReadObject(response.Content.ReadAsStreamAsync().Result);
                   Console.WriteLine(response);
                }
            }

            Console.ReadKey();


        }
        static string ReadConfigurationFile(string configFileName) 
        {
          
            //TODO remove hardcoding of content 
          string JSONstring = File.ReadAllText(configFileName);

                
           return JSONstring ;
               
        }
    }
}