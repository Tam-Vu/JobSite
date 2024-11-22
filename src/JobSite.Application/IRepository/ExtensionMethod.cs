namespace JobSite.Application.IRepository;

public static class ExtensionMethod
{
    public static IEnumerable<TEntity> Except<TEntity, TKey>(
    this IEnumerable<TEntity> source,
    IEnumerable<TEntity> target,
    Func<TEntity, TKey> keySelector)
    {
        var targetKeys = new HashSet<TKey>(target.Select(keySelector));
        foreach (var item in source)
        {
            if (!targetKeys.Contains(keySelector(item)))
            {
                yield return item;
            }
        }
    }

    public static string FormatMonthYear(int month, int year)
    {
        return string.Format("{0}/{1}", month, year);
    }
}