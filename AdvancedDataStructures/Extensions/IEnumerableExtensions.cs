using AdvancedDataStructures.ConcatenatedList;

namespace AdvancedDataStructures.Extensions
{
	public static class IEnumerableExtensions
	{
		public static ConcatenatedLinkedList<T> ToConcatenatedList<T>(this IEnumerable<T> source)
		{
			return new ConcatenatedLinkedList<T>(source);
		}

		/// <summary>
		/// This method is like a Select, but can be used for side effects.
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (var item in source)
			{
				action(item);
				yield return item;
			}
		}

		/// <summary>
		/// This method is like a Select, but can be used for side effects.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
		{
			int index = 0;
			foreach (var item in source)
			{
				action(item, index);
				index++;
				yield return item;
			}
		}

		/// <summary>
		/// Applies the action to each element and replaces it with the result.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static IEnumerable<T> ForEach<T>(this IList<T> source, Func<T, T> action)
		{
			for (int i = 0; i < source.Count; i++)
			{
				source[i] = action(source[i]);
			}
			return source;
		}

		public static IEnumerable<T> OneIfEmpty<T>(this IEnumerable<T> source, T value)
		{
			using var enumerator = source.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					yield return enumerator.Current;
				} while (enumerator.MoveNext());
			}
			else
			{
				yield return value;
			}
		}
	}
}
