using ShopPhone;
using ShopPhone.Data;
using ShopPhone.Enums;
using ShopPhone.Models;
using System.Linq;

namespace ShopPhone 
{
    public class Program
    {
        static PhonesService Service = new PhonesService();

        public static void Main()
        {
            Console.WriteLine("Online shop phone");
            MenuHelper.MainMenu();
            Console.WriteLine();
        }
    }
}