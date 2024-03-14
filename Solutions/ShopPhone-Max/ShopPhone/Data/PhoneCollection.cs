using ShopPhone;
using ShopPhone.Data;
using ShopPhone.Enums;
using System.Drawing;
using ShopPhone.Enums.Models;
static class PhoneCollection
{
    public static void SetupInitialCollection()
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
        var List = new List<Phone> { SamsungS23, SamsungA24, PocoM4, PocoM5, Iphone15promax, Iphone14pro, };
        var Service = new PhonesService();
        foreach(var item in List) 
        {
            Service.Add(item);
        }
    }
}