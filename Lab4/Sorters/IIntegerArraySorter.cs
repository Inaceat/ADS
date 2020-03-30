namespace Lab4.Sorters
{
    public interface IIntegerArraySorter
    {
        void Sort(int[] data);

        (int swaps, int compares) SortAndCountSwapsAndCompares(int[] data);
    }
}