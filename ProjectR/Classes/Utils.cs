namespace ProjectR.Classes
{
    internal class Utils
    {
        public static string TrimString(string input, int maxLength)
        {
            return input.Length <= maxLength ? input : $"{input[..maxLength]}...";
        }
    }
}
