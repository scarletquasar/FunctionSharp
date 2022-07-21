using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace FunctionSharp.Tests.Extensions
{
    public class IEnumerableExtensionsTests
    {
        [Fact]
        public void IEnumerableForEachShouldWorkProperly()
        {
            IEnumerable<string> baseCollection = new List<string>() { "test" };
            List<string> resultCollection = new();

            baseCollection.ForEach(resultCollection.Add);

            Assert.Equal("test", resultCollection.ElementAt(0));
        }

        [Fact]
        public async void IEnumerableForEachAsyncShouldWorkProperly()
        {
            IEnumerable<string> baseCollection = new List<string>() { "test" };
            List<string> resultCollection = new();

            await baseCollection.ForEachAsync(resultCollection.Add);

            Assert.Equal("test", resultCollection.ElementAt(0));
        }

        [Fact]
        public void IEnumerableMapShouldWorkProperly()
        {
            IEnumerable<string> baseCollection = new List<string>() { "test" };
            List<string> resultCollection = baseCollection.Map(x => x + "1").ToList();

            Assert.Equal("test1", resultCollection.ElementAt(0));
        }

        [Fact]
        public async void IEnumerableMapAsyncShouldWorkProperly()
        {
            IEnumerable<string> baseCollection = new List<string>() { "test" };
            List<string> resultCollection = (await baseCollection.MapAsync(x => x + "1")).ToList();

            Assert.Equal("test1", resultCollection.ElementAt(0));
        }
    }
}
