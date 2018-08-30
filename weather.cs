using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Xaml;
using System.IO;
using System.Runtime.Serialization.Json;


namespace world
{
    class Weather
    {

        public float GetCurrentTemperature(string city, string countrycode)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "," + countrycode + "&APPID=6eb1b56a44171680a7ac1497d62dedb6";
            HttpClient httpClient = new HttpClient();
            Task<string> taskAsString = httpClient.GetStringAsync(url);
            string getUrlResult = taskAsString.Result;
            exampleModel s = new JavaScriptSerializer().Deserialize<exampleModel>(getUrlResult);
            return s.main.temp;
        }
        public string str = "hello";
    }
    class exampleModel
    {
        public mainModel main { get; set; }
    }
    class mainModel
    {
        public float temp { get; set; }
    }


}



