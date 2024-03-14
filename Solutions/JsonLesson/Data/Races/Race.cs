using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonLesson.Enums;

namespace JsonLesson.Data.Races
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public RaceCategory Category { get; set; }

        public Location Location { get; set; }
    }
}
