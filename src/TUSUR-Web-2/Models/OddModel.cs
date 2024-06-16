namespace Lab1.Models
{
    public class OddModel
    {
        public static bool check(int number)
        {
            string string_number = number.ToString();
            if (string_number.Length == 3 & number % 2 != 0)
            {
                return true;
            }
            return false;
        }
    }
}
