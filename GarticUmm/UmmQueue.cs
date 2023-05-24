using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmmQueue;

namespace UmmQueue
{
    class Node<T>
    {
        public T value;
        public Node<T> next;
        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
    }

    class PersonQueue<T>
    {
        public Node<T> first;
        public Node<T> last;

        public PersonQueue()
        {
            this.first = null;
            this.last = null;
        }

        public void enQueue(T person)
        {
            Node<T> newnode = new Node<T>(person);
            if (last == null)
            {
                first = newnode;
                last = newnode;
            }
            else
            {
                last.next = newnode;
                last = newnode;
            }
        }
        public void deQueue()
        {
            if (first == null)
                return;
            first = first.next;
            if (first == null)
                last = null;
            return;
        }
        public void pop(T index)
        {
            if (first == null)
                return;
            Node<T> previous = null;
            Node<T> current = first;

            while (current != null)
            {
                if (current.value.Equals(index))
                {
                    if (previous == null)
                    {
                        first = current.next;
                        if (first == null)
                            last = null;
                    }
                    previous.next = current.next;
                    if (current.next == null)
                        last = previous;

                }
                previous = current;
                current = current.next;
            }

        }

        public T search(int idx)
        {
            idx--;
            Node<T> current = first;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == idx)
                {
                    return current.value;
                }
                current = current.next;
                currentIndex++;
            }
            throw new IndexOutOfRangeException("Index is out of range");
        }

    }
}