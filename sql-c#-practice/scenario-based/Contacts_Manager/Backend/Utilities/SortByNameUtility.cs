namespace Utilities;

internal sealed class SortByName : BaseSorter
{
    protected override string GetOrderByColumn()
    {
        return "FirstName, LastName";
    }

    protected override string GetSortTitle()
    {
        return "NAME";
    }
}
