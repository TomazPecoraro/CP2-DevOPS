namespace Sprint3.API.Extensions
{
    public static class IntegerExtensions
    {
        public static string ToCurrency(this int value)
        {
            return value.ToString("C");
        }


        public static int ToDiv10(this int value)
        {
            return value / 10;
        }
    }
}
