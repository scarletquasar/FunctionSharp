namespace FunctionSharp
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> iterable, Action<T> callback, int index = 0)
        {
            int length = iterable.Count();

            for (; index < length; index++)
            {
                callback(iterable.ElementAt(index));
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> iterable, Action<T> callback, int index = 0)
        {
            int length = iterable.Count();
            for (; index < length; index++)
            {
                await Task.Run(() => callback(iterable.ElementAt(index))).ConfigureAwait(false);
            }
        }

        public static IEnumerable<T> Map<T>(this IEnumerable<T> iterable, Func<T, T> callback, int index = 0)
        {
            int length = iterable.Count();
            HashSet<T> result = new();

            for (; index < length; index++)
            {
                result.Add(callback(iterable.ElementAt(index)));
            }

            return result;
        }

        public static async Task<IEnumerable<T>> MapAsync<T>(this IEnumerable<T> iterable, Func<T, T> callback, int index = 0)
        {
            int length = iterable.Count();
            HashSet<T> result = new();

            for (; index < length; index++)
            {
                var value = await Task.Run(() => callback(iterable.ElementAt(index))).ConfigureAwait(false);
                result.Add(value);
            }

            return result;
        }
    }
}
