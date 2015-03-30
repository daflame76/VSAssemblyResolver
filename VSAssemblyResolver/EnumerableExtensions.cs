using System;
using System.Collections.Generic;
using System.Linq;

namespace SergejDerjabkin.VSAssemblyResolver
{
    /// <summary>
    /// Extension methods for supporting enumerable collections.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Selects the maximum element of the given collection based on the given comparison.
        /// </summary>
        /// <typeparam name="TElement">The type of the element.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="compare">The comparison method.</param>
        /// <returns>
        /// The maximum element found in the collection.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">if the source collection is null.</exception>
        public static TElement MaxElement<TElement>(this IEnumerable<TElement> source, Comparison<TElement> compare)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var sourceItems = source.ToArray();
            if (sourceItems.Length == 0)
                return default(TElement);

            TElement maxElement = sourceItems[0];
            foreach (var item in sourceItems.Skip(1))
            {
                if (compare(item, maxElement) > 0)
                    maxElement = item;
            }

            return maxElement;
        }
    }
}