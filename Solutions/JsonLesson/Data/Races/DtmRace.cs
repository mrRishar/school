using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonLesson.Enums;

namespace JsonLesson.Data.Races
{
    public class DtmRace : Race
    {
        public int DistanceInMin { get; set; } = 50;

        public new RaceCategory Category { get; set; } = RaceCategory.GT3;
    }
}
