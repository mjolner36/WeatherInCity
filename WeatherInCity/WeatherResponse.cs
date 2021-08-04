using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInCity
{
    class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public SysInfo Sys { get; set; }

        public int Timezone { get; set; }
        public string Name { get; set; }
    }
}
