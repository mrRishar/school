using ShopPhone.ConsoleApp.Helpers;
using Store.Application.Enums;
using Store.Application.Models;
using Store.Application.Models.Services;

namespace ShopePhone.ConsoleApp.Helper
{
    public class PhoneHelper
    {
        public static void RequestToBuy(uint phoneId)
        {
            var service = new PhonesService();
            var phone = service.Get(phoneId);
            if (phone == null)
            {
                Console.WriteLine($"Phone #{phoneId} not found. Please try again");
                return;
            }
            Console.WriteLine($"\r\nDo you want to buy {phone.Model}?");
            Console.WriteLine("1 - To Buy \r\n2- - Go To Back ");

            var operation = CommonHelper.ReadPositiveNumber();
            if (operation == 1)
            {
                Console.WriteLine($"Enter your email so our team will contact you to complete the deal!");

                var email = Console.ReadLine();

                Console.WriteLine($"We sent you an email with order details to {email}\r\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Congratulations you are happy owner of {phone.Model}{phone.Model}\r\n"
                ); Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void PrintPhonesDetails(uint phoneId)
        {
            Console.WriteLine($"You selected phone number #{phoneId}");
            Console.WriteLine();

            var service = new PhonesService();

            var phone = service.Get(phoneId);
            if (phone == null)
            {
                Console.WriteLine($"Phone #{phoneId} not found. Please try again");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Model: {phone.Model}");
                Console.WriteLine($"Id: {phone.Id}");
                Console.WriteLine($"Id: {phone.Id}");
                Console.WriteLine($"Color: {phone.Color}");
                Console.WriteLine($"Height: {phone.Height}");
                Console.WriteLine($"Price: {phone.Price}");


                if (phone is Iphone iphone)
                {
                    Console.WriteLine($"SpeedCharging: {iphone.SpeedCharging}");
                    Console.WriteLine($"HasChargingBlock: {iphone.HasChargingBlock}");
                }
                else if (phone is Poco poco)
                {
                    Console.WriteLine($"CameraMP: {poco.CameraMP}");
                    Console.WriteLine($"SimCardsCount: {poco.SimCardsCount}");
                }
                else if (phone is Samsung samsung)
                {
                    Console.WriteLine($"ShockProof: {samsung.ShockProof}");
                    Console.WriteLine($"Waterproof: {samsung.Waterproof}");
                }

                Console.WriteLine($"Price: {phone.Price}");
                RequestToBuy(phone.Id);
            }
            Console.ReadKey();
        }

        public static void PrintPhones(List<Phone> phoneCollection)
        {
            Console.WriteLine($"Phone available at this moment: {phoneCollection.Count} ");

            foreach (var item in phoneCollection)
            {
                Console.WriteLine($"Model: {item.Model} #{item.Id}");
                Console.WriteLine($"Color: {item.Color}");
                Console.WriteLine($"Price: {item.Price}");
            }
        }

        public static List<Phone> GetPhoneCollection(MainMenu category)
        {
            var service = new PhonesService();

            var phoneCollection = service.GetAll();
            if (category == MainMenu.Iphone)
            {
                return phoneCollection.Where(f => f is Iphone).ToList();
            }
            if (category == MainMenu.Poco)
            {
                return phoneCollection.Where(f => f is Poco).ToList();
            }
            if (category == MainMenu.Samsung)
            {
                return phoneCollection.Where(f => f is Samsung).ToList();
            }
            return phoneCollection;
        }
    }
}