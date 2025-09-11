namespace AdvancedDataStructures.Extensions
{
	public static partial class IEnumerableExtensions
	{
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (var item in source)
			{
				action(item);
				yield return item;
			}
		}

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

		public static IEnumerable<T> ForEach<T>(this IList<T> source, Func<T, T> action)
		{
			for (int i = 0; i < source.Count; i++)
			{
				source[i] = action(source[i]);
			}
			return source;
		}
	}
}