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


namespace world
{
    class Program
    {
        static void Main(string[] args)
        {
            weather weather = new weather();
            float tempkdp = weather.GetCurrentTemperature("kadapa", "in");
            Console.WriteLine("temperature :  " + tempkdp);
            Console.ReadKey();
        }
    }
}
