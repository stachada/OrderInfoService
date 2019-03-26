namespace OrderInfoService.WinFormsApp.Infrastructure
{
    public static class CastingHelpers
    {
        public static T Cast<T>(object obj, T targetType)
        {
            return (T)obj;
        }
    }
}
