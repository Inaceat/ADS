namespace Lab4
{
    public interface IIntegerArraySorter
    {
        void Sort(int[] data);

        (int swaps, int compares) SortAndCountSwapsAndCompares(int[] data);
    }
}