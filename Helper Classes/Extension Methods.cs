using System;
using System.Collections.Generic;
using System.Text;
using DelaunatorSharp;

namespace lab02
{
    public static class ExtensionMethods
    {
        public static HashSet<V> ConvertAll<T, V>(this HashSet<T> set, Func<T, V> functor)
        {
            HashSet<V> ret = new HashSet<V>();

            foreach (var element in set)
                ret.Add(functor(element));

            return ret;
        }

        public static List<T> ToList<T>(this HashSet<T> set)
        {
            List<T> ret = new List<T>();

            foreach (var element in set)
                ret.Add(element);

            return ret;
        }

        public static T[] ToArray<T>(this HashSet<T> set) => set.ToList().ToArray();

        public static IEnumerable<V> ConvertAll<T, V>(this IEnumerable<T> collection, Func<T, V> functor)
        {
            List<V> ret = new List<V>();

            foreach (var element in collection)
                ret.Add(functor(element));

            return ret;
        }
    }
}
