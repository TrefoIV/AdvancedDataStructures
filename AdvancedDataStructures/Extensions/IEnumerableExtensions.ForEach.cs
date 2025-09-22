namespace AdvancedDataStructures.Extensions
{
	public static partial class IEnumerableExtensions
	{
		/// <summary>
		/// Performs the specified action on each element of the <see cref="IEnumerable{T}"/> and returns the elements. It can be used to
		/// perform side effects while iterating through a sequence.
		/// </summary>
		/// <remarks>This method allows you to perform an action on each element of the sequence while maintaining the
		/// ability to chain further LINQ operations. The action is executed as the sequence is enumerated.</remarks>
		/// <typeparam name="T">The type of the elements in the source sequence.</typeparam>
		/// <param name="source">The sequence of elements to iterate over. Cannot be <see langword="null"/>.</param>
		/// <param name="action">The action to perform on each element. Cannot be <see langword="null"/>.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> that contains the same elements as the input sequence.</returns>
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (var item in source)
			{
				action(item);
			}
			return source;
		}

		/// <summary>
		/// Performs the specified action on each element of the <see cref="IEnumerable{T}"/> along with its index and returns the elements. It can be used to
		/// perform side effects while iterating through a sequence.
		/// </summary>
		/// <remarks>This method allows you to perform an action on each element of the sequence while
		/// maintaining the ability to chain further LINQ operations. The action is executed as the sequence is enumerated.</remarks>
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
			}
			return source;
		}

		/// <summary>
		/// Performs the specified action on each element of the <see cref="IList{T}"/>, replacing each element with the result of the action, 
		/// and returns the modified list.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static IList<T> ForEach<T>(this IList<T> source, Func<T, T> action)
		{
			for (int i = 0; i < source.Count; i++)
			{
				source[i] = action(source[i]);
			}
			return source;
		}
	}
}