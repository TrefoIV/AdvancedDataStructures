namespace AdvancedDataStructures.Extensions
{
	public static class DictionaryExtensions
	{
		public static TValue GetOrInsert<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue def)
		{
			if (dict.TryGetValue(key, out TValue value))
			{
				return value;
			}
			dict[key] = def;
			return def;
		}
	}
}
