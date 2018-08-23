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


namespace world
{
    class Program
    {
        static void Main(string[] args)
        {
            //REAd configuration file into string
            string filecontent = ReadConfigurationFile("cities.json");
            //parse filecontent

            CityConfig[] cityConfigArray = new JavaScriptSerializer().Deserialize<CityConfig[]>(filecontent);
            weather weather = new weather();
            foreach (CityConfig cityConfig in cityConfigArray)
            {
                Console.WriteLine(cityConfig.city);
              
                float tempkdp = weather.GetCurrentTemperature(cityConfig.city, cityConfig.countrycode);
                Console.WriteLine("temperature :  " + tempkdp);
            }
           
            Console.ReadKey();


        }
        static string ReadConfigurationFile(string configFileName) 
        {
          
            //TODO remove hardcoding of content 
          string JSONstring = File.ReadAllText("E:/c#/weatherProgram/world/cities.json");

                
           return JSONstring ;
               
        }
    }
}