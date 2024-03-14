﻿using Store.Application.Extentions;

namespace ShopPhone.ConsoleApp.Helpers
{
    internal class CommonHelper
    {
        public static uint ReadPositiveNumber(uint maxLimit = uint.MaxValue, params string[] labels)
        {
            while (true)
            {
                foreach (var item in labels)
                {
                    Console.WriteLine(item);
                }
                uint.TryParse(Console.ReadLine(), out uint number);
                if (number > 0 && number <= maxLimit)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine($"Typed value is not valid value.Please try agin");
                }
            }
        }

        public static bool ReadBool(string labels)
        {
            Console.WriteLine($"{labels}\r\n 1 - Yes \r\n 2 - No");
            return Console.ReadLine() == "1";
        }

        public static TEnum ReadEnumValue<TEnum>(string label)
            where TEnum : struct, Enum, IComparable, IFormattable, IConvertible
        {
            Console.WriteLine(label);
            var max = typeof(TEnum).ToList<TEnum>()
             .Max(f => Convert.ToUInt32(f));
            var labels = typeof(TEnum).ToList<TEnum>()
             .Select(f => $"{Convert.ToUInt32(f)} - {f}")
             .ToArray();

            var result = ReadPositiveNumber(max,labels);
            return typeof(TEnum).ToList<TEnum>().FirstOrDefault(f => Convert.ToUInt32(f) == result);
        }
    }
}