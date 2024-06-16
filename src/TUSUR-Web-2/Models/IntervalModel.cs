namespace Lab1.Models
{
    public class IntervalModel
    {
        public static int[] InInterval(int[] interval, int xmin, int xmax)
        {
            List<int> result = new List<int>();
            foreach (var item in interval)
            {
                if (xmin < item & item < xmax)
                {
                    result.Add(item);
                }
            }
            return result.ToArray();
        }
    }
}
