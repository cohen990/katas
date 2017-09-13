using stack;
using Xunit;

namespace stack_tests
{
    public class StackShould
    {
        [Fact]
        public void ReturnPushedObjectWhenPopped()
        {
            var expected = "only";
            var stack = new Stack();

            stack.Push(expected);

            Assert.Equal(expected, stack.Pop());
        }

        [Fact]
        public void ReturnPushedObjectsInReverseOrder()
        {
            var expectedFirst = "first";
            var expectedSecond = "second";
            var stack = new Stack();

            stack.Push(expectedSecond);
            stack.Push(expectedFirst);

            Assert.Equal(expectedFirst, stack.Pop());
            Assert.Equal(expectedSecond, stack.Pop());
        }
    }
}