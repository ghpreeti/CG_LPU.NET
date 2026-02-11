using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLINQExtensionMethods
{
    public static class LINQExtensionMethod
    {
       

        // 1. WhereEx
        public static IEnumerable<T> WhereEx<T>(
            this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        // 2. SelectEx
        public static IEnumerable<TResult> SelectEx<T, TResult>(
            this IEnumerable<T> source,
            Func<T, TResult> selector)
        {
            foreach (T item in source)
            {
                yield return selector(item);
            }
        }

        // 3. DistinctEx
        public static IEnumerable<T> DistinctEx<T>(
            this IEnumerable<T> source)
        {
            HashSet<T> seen = new HashSet<T>();

            foreach (T item in source)
            {
                if (!seen.Contains(item))
                {
                    seen.Add(item);
                    yield return item;
                }
            }
        }

    }
}
