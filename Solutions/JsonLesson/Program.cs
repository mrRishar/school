using JsonLesson.Data;
using JsonLesson.Data.Races;
using JsonLesson.Services;

namespace JsonLesson;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Type 1 to view races");
            Console.WriteLine("Type 2 to add new race");
            Console.WriteLine("Type 3 to view particular race");

            var mode = Console.ReadLine();

            var service = new RacesService();
            var collection = service.GetAll();

            if (mode == "1")
            {
                foreach (var item in collection)
                {
                    DisplayRace(item);
                }
            }
            else if (mode == "2")
            {
                service.Add(
                    new DtmRace
                    {
                        Name = "Hockenheimring",
                        Date = new DateTime(DateTime.Now.Year, 10, 14),
                        Location = new Location { City = "Hockenheim", Country = "Germany" },
                        DistanceInMin = 55
                    });
            }
            else if (mode == "3")
            {
                Console.Write("Enter race id: ");
                var id = Convert.ToInt32(Console.ReadLine());

                var race = service.Get(id);
                if (race != null)
                {
                    DisplayRace(race);
                }
            }

            Console.ReadKey();
        }
    }

    private static void DisplayRace(Race race)
    {
        Console.WriteLine($"Name: {race.Name} #{race.Id}");
        Console.WriteLine($"Date: {race.Date}");
        Console.WriteLine($"Location: {race.Location.City}, {race.Location.Country}");
        if (race is DtmRace dtm)
        {
            Console.WriteLine($"Distance: {dtm.DistanceInMin} min");
        }

        Console.WriteLine();
    }
}