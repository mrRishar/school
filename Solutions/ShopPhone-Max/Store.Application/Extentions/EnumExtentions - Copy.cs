namespace Store.Application.Extentions
{
    public static partial class EnumExtensions
    {
        public static List<TEnum> ToList<TEnum>(this Type type) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return System.Enum.GetValues(type).OfType<TEnum>().ToList();
        }
    }

}
