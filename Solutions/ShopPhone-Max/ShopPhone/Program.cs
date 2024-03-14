using ShopPhone.ConsoleApp.Helpers;
using Store.Application.Models.Services;
using Store.Data1;

namespace ShopPhone.ConsoleApp
{
    static class Program
    {
        public static void Main()
        {
            var list = SeedPhoneCollection.GetAll();
            var service = new PhonesService();
            foreach (var item in list)
            service.Add(item);
            Console.WriteLine("Online shop phone");
            MenuHelper.MainMenu();
        }
    }
}