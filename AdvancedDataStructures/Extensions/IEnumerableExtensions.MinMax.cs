namespace AdvancedDataStructures.Extensions
{
	public static partial class IEnumerableExtensions
	{
		public static (T min, T max) MinMax<T>(this IEnumerable<T> source) where T : IComparable<T>
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			using var enumerator = source.GetEnumerator();
			if (!enumerator.MoveNext())
				throw new InvalidOperationException("Sequence contains no elements");
			T min = enumerator.Current;
			T max = enumerator.Current;
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CompareTo(min) < 0)
					min = enumerator.Current;
				if (enumerator.Current.CompareTo(max) > 0)
					max = enumerator.Current;
			}
			return (min, max);
		}

		public static (T min, T max) MinMax<T>(this IEnumerable<T> source, IComparer<T> comparer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (comparer == null)
				throw new ArgumentNullException(nameof(comparer));
			using var enumerator = source.GetEnumerator();
			if (!enumerator.MoveNext())
				throw new InvalidOperationException("Sequence contains no elements");
			T min = enumerator.Current;
			T max = enumerator.Current;
			while (enumerator.MoveNext())
			{
				if (comparer.Compare(enumerator.Current, min) < 0)
					min = enumerator.Current;
				if (comparer.Compare(enumerator.Current, max) > 0)
					max = enumerator.Current;
			}
			return (min, max);
		}

		public static (T min, T max) MinMaxBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (keySelector == null)
				throw new ArgumentNullException(nameof(keySelector));
			using var enumerator = source.GetEnumerator();
			if (!enumerator.MoveNext())
				throw new InvalidOperationException("Sequence contains no elements");
			T min = enumerator.Current;
			T max = enumerator.Current;
			TKey minKey = keySelector(min);
			TKey maxKey = keySelector(max);
			while (enumerator.MoveNext())
			{
				TKey currentKey = keySelector(enumerator.Current);
				if (currentKey.CompareTo(minKey) < 0)
				{
					min = enumerator.Current;
					minKey = currentKey;
				}
				if (currentKey.CompareTo(maxKey) > 0)
				{
					max = enumerator.Current;
					maxKey = currentKey;
				}
			}
			return (min, max);
		}

		public static (T min, T max) MinMax<T>(this IEnumerable<T> source, Func<T, bool> selector) where T : IComparable<T>
		{
			return source.Where(selector).MinMax();
		}
	}
}