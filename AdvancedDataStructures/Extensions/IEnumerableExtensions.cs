using AdvancedDataStructures.ConcatenatedList;

namespace AdvancedDataStructures.Extensions
{
	public static class IEnumerableExtensions
	{
		public static ConcatenatedLinkedList<T> ToConcatenatedList<T>(this IEnumerable<T> source)
		{
			return new ConcatenatedLinkedList<T>(source);
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (var item in source)
			{
				action(item);

				yield return item;
			}
		}
	}
}
