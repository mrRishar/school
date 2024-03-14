using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonLesson.Enums;

namespace JsonLesson.Data.Races
{
    public class F1Race : Race
    {
        public int DistanceInLaps { get; set; }
        public new RaceCategory Category { get; set; } = RaceCategory.F1;
    }
}