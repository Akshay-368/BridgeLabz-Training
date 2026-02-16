namespace Utilities;

internal sealed class SortByLocation : BaseSorter
{
    protected override string GetOrderByColumn()
    {
        return "Address";
    }

    protected override string GetSortTitle()
    {
        return "LOCATION";
    }
}
