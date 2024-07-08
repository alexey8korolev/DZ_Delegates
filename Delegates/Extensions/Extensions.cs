using System.Collections;

namespace Delegates.Extensions;

public static partial class EnumerableExt
{
    public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter)
        where T : class
    {
        if (e == null)
        {
            throw new Exception("Нет элемента");
        }

        if (getParameter == null)
        {
            throw new Exception("Не указана функция");
        }

        T value;

        var el = e.GetEnumerator();

        if (!el.MoveNext())
        {
            throw new Exception("Нет элементов");
        }

        value = (T)el.Current;

        if (!el.MoveNext())
        {
            return value;
        }

        T x = (T)el.Current;

        if (getParameter(x) > getParameter(value))
        {
            value = x;
        }

        while (el.MoveNext())
        {
            x = (T)el.Current;

            if (getParameter(x) > getParameter(value))
            {
                value = x;
            }
        }

        return value;
    }
}
