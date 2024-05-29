namespace Core.Utilities;

internal static class ReadonlyList
{
    internal static IReadOnlyList<T> AddItem<T>(this IReadOnlyList<T> list, T arg)
    {
        var temp = list.ToList();
        temp.Add(arg);
        return temp;
    }

    internal static IReadOnlyList<T> RemoveItem<T>(this IReadOnlyList<T> list, T arg)
    {
        var temp = list.ToList();
        temp.Remove(arg);
        return temp;
    }
}