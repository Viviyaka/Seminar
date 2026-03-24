namespace Quick
{
    internal class Program
    {
        static void Main(string[] args)
        {
         List<int> list = new List<int> { 5, 3, 8, 4, 2, 7, 9, 1, 10, 5};
            List<int> sortedList = QuickSort(list);
            Console.WriteLine(string.Join(", ", sortedList));
        }
        static List<int> QuickSort(List<int> list)
        {
            if (list.Count <= 1)
                return list;
         int pivot = list[list.Count / 2];
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            List<int> pivotList = new List<int>();
            foreach (int item in list)
            {
                if (item < pivot)
                    left.Add(item);
                if (item == pivot)
                    pivotList.Add(item);
                else if (item > pivot)
                    right.Add(item);
            }
            List<int> sortedLeft = QuickSort(left);
            List<int> sortedRight = QuickSort(right);
            List<int> sortedList = new List<int>();
            sortedList.AddRange(sortedLeft);
            sortedList.AddRange(pivotList);
            sortedList.AddRange(sortedRight);
            return sortedList;
        }

    }
}
