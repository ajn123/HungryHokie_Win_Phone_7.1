using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace VTHungryHokies
{
   public class DiningCenters
    {

        [JsonProperty("open")]
        public DiningCenters[] Centers { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("link")]
        public string link { get; set; }

        [JsonProperty("opens")]
        public string opens { get; set; }

        [JsonProperty("closes")]
        public string closes{ get; set; }

        [JsonProperty("image")]
        public string image { get; set; }


        public String OpenAndClose( int i)
        {
            if (this.Centers[i].closes != null)
            {
                return "Closes at " + this.Centers[i].closes;
            }
            else if (this.Centers[i].opens != null)
            {
                return "Opens at " + this.Centers[i].closes;

            }
            else
            {
                return "Open Now";

            }


        }







    }
}
