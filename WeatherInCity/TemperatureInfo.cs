using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInCity
{
    class TemperatureInfo
    {
        public float Temp { get; set; }
        public float Humidity { get; set; }
    }
    class SysInfo
    {
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}
