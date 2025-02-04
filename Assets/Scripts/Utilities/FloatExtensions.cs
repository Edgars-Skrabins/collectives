namespace Collectives.Utilities
{
    public static class FloatExtensions
    {
        public static string ToTimeFormat(this float _seconds)
        {
            int hours = (int)_seconds / 3600;
            int minutes = (int)_seconds / 60 % 60;
            int seconds = (int)_seconds % 60;
            return $"{hours:00}:{minutes:00}:{seconds:00}";
        }
    }
}