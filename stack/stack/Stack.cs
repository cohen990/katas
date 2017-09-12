using System.Collections.Generic;
using System.Linq;

namespace stack
{
    public class Stack
    {
        private readonly LinkedList<object> _items;

        public Stack()
        {
            _items = new LinkedList<object>();
        }

        public void Push(object item)
        {
            _items.AddFirst(item);
        }

        public object Pop()
        {
            var first = _items.First();
            _items.RemoveFirst();
            return first;
        }
    }
}
