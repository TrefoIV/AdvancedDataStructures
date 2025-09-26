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

		public static Dictionary<TKey, TValue> Merge<TKey, TValue>(this Dictionary<TKey, TValue> dict, Dictionary<TKey, TValue> other) where TKey : notnull where TValue : IMegiable
		{
			if (other is null) return dict;
			Dictionary<TKey, TValue> result = new();
			foreach (var key in dict.Keys) { result.Add(key, dict[key]); }
			foreach (var key in other.Keys)
			{
				TValue value = other[key];
				if (dict.TryGetValue(key, out TValue? v))
				{
					value = value.Merge(v);
				}
				result[key] = value;
			}
			return result;
		}
	}
}
