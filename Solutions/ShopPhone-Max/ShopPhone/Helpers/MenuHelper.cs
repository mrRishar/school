using ShopePhone.ConsoleApp.Helper;
using Store.Application.Enums;
using Store.Application.Models.Services;

namespace ShopPhone.ConsoleApp.Helpers
{
    public class MenuHelper
    {
        public static void MainMenu()
        {
            for (int i = 0; i < 20; i++)
            {
                Choise();
            }
            Console.WriteLine("You reached limit of views of the catalog");
        }

        public static void Choise()
        {
            Console.WriteLine("Select category and press enter");
            Console.WriteLine("1-Iphone");
            Console.WriteLine("2-Poco");
            Console.WriteLine("3-Samsung");
            Console.WriteLine("4-Price filter");
            Console.WriteLine("5-All Phone");

            var category = (MainMenu)CommonHelper.ReadPositiveNumber();

            var phonesService = new PhonesService();

            var phonesCollection = PhoneHelper.GetPhoneCollection(category);

            if (category == Store.Application.Enums.MainMenu.Pricefilter)
            {
                Console.WriteLine("Tyre you price: ");

                var price = Convert.ToDouble(Console.ReadLine());
                phonesCollection = phonesCollection
                    .Where(p => p.Price <= price)
                    .ToList();
            }
            else if (category == Store.Application.Enums.MainMenu.PrivateMenu)
            {
                HiddenMenu();
            }

            PhoneHelper.PrintPhones(phonesCollection);
        }

        static void HiddenMenu()
        {
            var NickName = Console.ReadLine();
            if (NickName != "NickName")
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

            var service = new PhonesService();
            var category = CommonHelper.ReadEnumValue<SecretMenu>("HiddenMenu");
            if (category == SecretMenu.Delete)
            {
                Console.WriteLine("Provide id");

                var id = CommonHelper.ReadPositiveNumber();
                service.Delete(id);
            }
            else if (category == SecretMenu.Add)
            {
                Console.WriteLine("Adding a new phone");

                var phoneCategory = CommonHelper.ReadEnumValue<PhoneCategory>("Enter brand");

                Console.WriteLine("Enter model");
                string model = Console.ReadLine();

                var color = CommonHelper.ReadEnumValue<PhoneColor>("Enter color number");

                var height = CommonHelper.ReadPositiveNumber(20, "Enter Height");

                var width = CommonHelper.ReadPositiveNumber(15, "Enter Width");

                var price = (double)CommonHelper.ReadPositiveNumber(55_000, "Enter Price");
                Console.WriteLine("Phone added successfully");

                if (phoneCategory == PhoneCategory.Iphone)
                {
                    service.Add(new Iphone
                    {
                        Color = color,
                        Model = model,
                        Price = price,
                        Height = height,
                        Width = width,
                        HasChargingBlock = CommonHelper.ReadBool("Has Charging Block"),
                        SpeedCharging = CommonHelper.ReadBool("Has Speed Charging")
                    });

                }
                else if (phoneCategory == PhoneCategory.Poco)
                {
                    service.Add(new Poco
                    {
                        Color = color,
                        Model = model,
                        Price = price,
                        Height = height,
                        Width = width,
                        CameraMP = CommonHelper.ReadPositiveNumber(100, "Enter camera MP"),
                        SimCardsCount = CommonHelper.ReadPositiveNumber(3, "Enter sim card slot")

                    });
                }
                else if (phoneCategory == PhoneCategory.Samsung)
                {
                    var samsung = new Samsung
                    {
                        Color = color,
                        Model = model,
                        Price = price,
                        Height = height,
                        Width = width,
                        ShockProof = CommonHelper.ReadBool("Is Shock Proof"),
                        Waterproof = CommonHelper.ReadBool("Is Water Proof")
                    };
                    service.Add(samsung);
                }
            }
        }
    }
}