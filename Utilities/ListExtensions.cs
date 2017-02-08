using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapboxSharp.Utilities
{
    public static class ListExtensions
    {
        /// <summary>
        /// Removes the item at the specified index and returns it.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="list">A collection that inherits from IList</param>
        /// <param name="index">Index of the element that should be popped.</param>
        /// <returns></returns>
        public static T PopAt<T>(this List<T> list, int index)
        {
            T listItem = list[index];
            list.RemoveAt(index);
            return listItem;
        }

        /// <summary>
        /// Inserts the given object to the first index of the collection.
        /// </summary>
        /// <typeparam name="T">Generic List type</typeparam>
        /// <param name="list">A collection that inherits from IList</param>
        /// <param name="obj">Data to be inserted into collection</param>
        public static void Push<T>(this List<T> list, T obj)
        {
            list.Insert(0, obj);
        }
    }
}
