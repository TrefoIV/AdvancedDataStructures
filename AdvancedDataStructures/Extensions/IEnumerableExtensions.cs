using AdvancedDataStructures.ConcatenatedList;

namespace AdvancedDataStructures.Extensions
{
	public static partial class IEnumerableExtensions
	{
		public static ConcatenatedLinkedList<T> ToConcatenatedList<T>(this IEnumerable<T> source)
		{
			return new ConcatenatedLinkedList<T>(source);
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
