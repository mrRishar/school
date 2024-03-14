using Store.Application.Enums;
using Store.Application.Models;
using Store.Application.Services;

namespace ShopPhone.ConsoleApp.Helpers
{
    public class MenuHelper
    {
        static PhonesService Service = new PhonesService();
        public static void MainMenu()
        {
            for (int i = 0; i < 20; i++)
            {
                Choise();
            }
            Console.WriteLine("You reached limit of views of the catalog");

        }
        private static void Choise()
        {
            Console.WriteLine("Select category and press enter");
            Console.WriteLine("1-Iphone");
            Console.WriteLine("2-Poco");
            Console.WriteLine("3-Samsung");
            Console.WriteLine("4-Price filter");
            Console.WriteLine("5-All Phone");

            var category = (ControlPanel)ReadPositiveNumber();

            var phonesService = new PhonesService();

            var phonesCollection = phonesService.GetAll();


            if (category == ControlPanel.Iphone)
            {
                phonesCollection = phonesCollection
                    .Where(p => p is Iphone)
                    .ToList();
            }
            else if (category == ControlPanel.Poco)
            {
                phonesCollection = phonesCollection
                    .Where(p => p is Poco)
                    .ToList();
            }
            else if (category == ControlPanel.Samsung)
            {
                phonesCollection = phonesCollection
                    .Where(p => p is Samsung)
                    .ToList();
            }

            else if (category == ControlPanel.Pricefilter)
            {
                Console.WriteLine("Tyre you price: ");

                var price = Convert.ToDouble(Console.ReadLine());
                phonesCollection = phonesCollection
                    .Where(p => p.Price <= price)
                    .ToList();
            }
            else if (category == ControlPanel.PrivateMenu)
            {
                HiddenMenu();
            }

            PrintPhones(phonesCollection);
        }

        static bool ReadBool(string labels)
        {
            Console.WriteLine($"{labels}\r\n1 - Yes\r\n 2 - No");
            return Console.ReadLine() == "1";
        }

        static void HiddenMenu()
        {
            var NickName = Console.ReadLine();
            if (NickName != "NickName:")
            {
                Console.Clear();
                return;
            }
            Console.Write("Password:");
            var Password = Console.ReadLine();
            if (Password != "1111")
            {
                Console.Clear();
                return;
            }
            Console.WriteLine("HiddenMenu");
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Delete");
            var category = (SecretMenu)ReadPositiveNumber();
            if (category == SecretMenu.Delete)
            {
                Console.WriteLine("Provide id");

                var Service = new PhonesService();

                var id = ReadPositiveNumber();
                Service.Delete(id);
            }
            else if (category == SecretMenu.Add)
            {
                Console.WriteLine("Adding a new phone");

                Console.WriteLine("Enter brand");
                var phoneCategory = (PhoneCategory)ReadPositiveNumber();

                Console.WriteLine("Enter model");
                string model = Console.ReadLine();

                Console.WriteLine("Enter color number");
                Console.WriteLine("Black - 1,");
                Console.WriteLine("White - 2,");
                Console.WriteLine("Blue - 3,");
                Console.WriteLine("Red - 4,");
                Console.WriteLine("Yellow - 5");

                var color = (PhoneColor)ReadPositiveNumber();

                Console.WriteLine("Enter Height");
                var Height = ReadPositiveNumber();

                Console.WriteLine("Enter Width");
                var Width = ReadPositiveNumber();

                Console.WriteLine("Enter id");
                var id = ReadPositiveNumber();

                Console.WriteLine("Enter Price");
                var price = (double)ReadPositiveNumber();
                Console.WriteLine("Phone added successfully");

                var Service = new PhonesService();

                if (phoneCategory == PhoneCategory.Iphone)
                {
                    Console.WriteLine("Has ChargingBlock");
                    Console.WriteLine("Press 1 - yes");
                    Console.WriteLine("Press 2 - no");

                    var operation = Console.ReadLine();

                    Service.Add(new Iphone
                    {
                        Color = color,
                        Id = id,
                        Model = model,
                        Price = price,
                        Height = ReadPositiveNumber(),
                        Width = ReadPositiveNumber(),

                    });

                }
                else if (phoneCategory == PhoneCategory.Poco)
                {
                    Console.WriteLine("Has ChargingBlock");
                    Console.WriteLine("Press 1 - yes");
                    Console.WriteLine("Press 2 - no");

                    var operation = Console.ReadLine();

                    Service.Add(new Poco
                    {
                        Color = color,
                        Id = id,
                        Model = model,
                        Price = price,
                        Height = ReadPositiveNumber(),
                        Width = ReadPositiveNumber(),

                    });
                }
                else if (phoneCategory == PhoneCategory.Samsung)
                {
                    Console.WriteLine("Has ChargingBlock");
                    Console.WriteLine("Press 1 - yes");
                    Console.WriteLine("Press 2 - no");

                    var operation = Console.ReadLine();

                    var samsung = new Samsung
                    {
                        Color = color,
                        Id = id,
                        Model = model,
                        Price = price,
                        Height = ReadPositiveNumber(),
                        Width = ReadPositiveNumber(),

                    };
                    Service.Add(samsung);


                }
            }
        }

        static void RequestToBuyPhone(uint phoneId)
        {
            var phone = new PhonesService().Get(phoneId);
            if (phone == null)
            {
                Console.WriteLine($"Phone #{phoneId} not found. Please try agin");
                return;
            }

            if (ReadBool($"\r\nDo you want to buy {phone.Model}?"))
            {
                Console.WriteLine($"Enter youe email so out team will contract the oeder!");

                Console.WriteLine($"Please enter you FirstName:");
                var FirstName = Console.ReadLine();

                Console.WriteLine($"Please enter you LastName:");
                var LastName = Console.ReadLine();

                Console.WriteLine($"Please enter you MiddleName:");
                var MiddleName = Console.ReadLine();

                Console.WriteLine($"Please enter keep your address:");
                var address = Console.ReadLine();

                Console.WriteLine($"Please enter carry a mobile Number:");
                var Number = ReadPositiveNumber();

                Console.WriteLine($"Cash of card?");
                Console.WriteLine("1 - Card 2 - Cash");

                var Card = ReadPositiveNumber();
                if (Card == 1)
                {
                    Console.WriteLine($"Please enter keep the card number");
                    var number = Console.ReadLine();
                }

                Console.Write("Your budget:");
                var email = Console.ReadLine();

                Console.WriteLine($"We send you on email with order details to {email}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congratulations you are happy owner of {phone.Model}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ReadKey();

            }
            else
            {
                return;
            }

        }

        static uint ReadPositiveNumber(uint maxLimit = uint.MaxValue)
        {
            while (true)
            {
                Console.Write($"Enter numerical value:");
                uint.TryParse(Console.ReadLine(), out uint number);
                if (number > 0 && number <= maxLimit)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine($"Typed value is not valid number.Try again");
                }
            }
        }

        static void PrintPhones(List<Phone> phoneCollection)
        {
            Console.WriteLine($"Phone available at this moment: {phoneCollection.Count} ");

            foreach (var item in phoneCollection)
            {
                Console.WriteLine($"Model: {item.Model} #{item.Id}");
                Console.WriteLine($"Color: {item.Color}");
                Console.WriteLine($"Price: {item.Price}");
                Console.WriteLine();
            }
        }
    }
}