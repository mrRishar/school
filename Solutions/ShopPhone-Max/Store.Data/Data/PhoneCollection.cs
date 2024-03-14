using Store.Application.Enums;
using Store.Application.Models;

namespace Store.Data1
{
    public static class SeedPhoneCollection
    {
        public static List<Phone> GetAll()
        {
            var Iphone14pro = new Iphone
            {
                Model = "Iphone14pro",
                Height = 11,
                Width = 5,
                Color = PhoneColor.Black,
                Price = 64000,
                SpeedCharging = true,
                HasChargingBlock = false,
                Id = 1,
            };

            var Iphone15promax = new Iphone
            {
                Model = "Iphone15promax",
                Height = 12,
                Width = 6,
                Color = PhoneColor.White,
                Price = 76000,
                SpeedCharging = true,
                HasChargingBlock = false,
                Id = 2,
            };

            var PocoM5 = new Poco
            {
                Model = "PocoM5",
                Height = 12,
                Width = 7,
                Price = 7000,
                Color = PhoneColor.Blue,
                CameraMP = 100,
                SimCardsCount = 3,
                Id = 3,
            };

            var PocoM4 = new Poco
            {
                Model = "PocoM4",
                Height = 15,
                Width = 7,
                Price = 6000,
                Color = PhoneColor.Red,
                CameraMP = 65,
                SimCardsCount = 2,
                Id = 4,
            };

            var SamsungA24 = new Samsung
            {
                Model = "SamsungA24",
                Height = 14,
                Width = 6,
                Price = 11000,
                Color = PhoneColor.Black,
                ShockProof = false,
                Waterproof = true,
                Id = 5,
            };

            var SamsungS23 = new Samsung
            {
                Model = "SamsungS23",
                Height = 15,
                Width = 7,
                Price = 24000,
                Color = PhoneColor.Yellow,
                ShockProof = true,
                Waterproof = true,
                Id = 6,
            };
            return new List<Phone> { SamsungA24, SamsungS23,PocoM4,PocoM5,Iphone14pro,Iphone15promax };
        }
    }
}