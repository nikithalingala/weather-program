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
            Weather weather = new Weather();
          Console.WriteLine(weather.str);

            foreach (CityConfig cityConfig in cityConfigArray)
            {
                Console.WriteLine(cityConfig.city);
              
                float tempkdp = weather.GetCurrentTemperature(cityConfig.city, cityConfig.countrycode);
                Console.WriteLine("temperature :  " + tempkdp);
                //body
                // HttpClient post

                HttpClient httpClient= new HttpClient();
                // (httpClient.DefaultRequestHeaders).Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
             HttpRequestHeaders httpRequestHeaders= httpClient.DefaultRequestHeaders; 
               // HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> httpHeaderValueCollection = httpRequestHeaders.Accept;
              //  MediaTypeWithQualityHeaderValue mediaTypeWithQualityHeaderValue = new MediaTypeWithQualityHeaderValue("application/json");
              //  httpHeaderValueCollection.Add(mediaTypeWithQualityHeaderValue);
                httpRequestHeaders.Add("X-Insert-Key", "jzsjmfl5Qmntrkfrn28XL5VOTVkYU3ju");
               // httpRequestHeaders.Add("Content-Type", "application/json");
                httpRequestHeaders.Add("xyz", "abc");

                StringContent content = new StringContent("[{\"city\":\""+cityConfig.city+"\", \"countryCode\":\""+cityConfig.countrycode+"\" , \"eventType\":\"Temperature\" , \"temperature\":" + tempkdp+"}]",Encoding.UTF8, "application/json");
                Console.WriteLine(content.ReadAsStringAsync().Result);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
             var result = httpClient.PostAsync("https://insights-collector.newrelic.com/v1/accounts/1245525/events", content).Result;
               if( result.IsSuccessStatusCode)
                {
                    Console.WriteLine("SUCCESSFULLY POSTED DATA TO NEWRELIC");
                }
                else
                {
                    Console.WriteLine("FAILED TO SNED");
                    Console.WriteLine(result.ReasonPhrase);
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