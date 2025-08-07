using AdvancedDataStructures.ConcatenatedList;

namespace AdvancedDataStructures.Extensions
{
	public static class IEnumerableExtensions
	{
		public static ConcatenatedLinkedList<T> ToConcatenatedList<T>(this IEnumerable<T> source)
		{
			return new ConcatenatedLinkedList<T>(source);
		}
	}
}
