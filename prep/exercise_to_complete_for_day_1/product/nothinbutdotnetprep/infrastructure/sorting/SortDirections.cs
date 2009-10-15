namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class SortDirections
    {
        static public readonly SortDirection ascending = new AscendingSortDirection();
        static public readonly SortDirection descending = new DescendingSortDirection();
    }
}