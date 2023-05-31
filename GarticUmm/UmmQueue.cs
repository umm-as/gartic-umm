using System;
using System.Collections;
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

    class PersonQueue<T> : IEnumerable<T>
    {
        public Node<T> first;
        public Node<T> last;
        int size;
        public PersonQueue()
        {
            this.first = null;
            this.last = null;
            size = 0;
        }

        public void enQueue(T person)
        {
            Node<T> newnode = new Node<T>(person);
            if (first == null)
            {
                first = newnode;
                last = newnode;
            }
            else
            {
                last.next = newnode;
                last = last.next;
            }
            size++;
        }

        public T deQueue()
        {
            if (first == null)
                return default(T);

            Node<T> result = first;
            first = first.next;

            if (first == null)
                last = null;

            size--;
            return result.value;
        }

        public T pop(T index)
        {
            if (first == null)
                return default(T);

            Node<T> previous = null;
            Node<T> current = first;

            Node<T> result = null;

            while (current != null)
            {
                if (current.value.Equals(index))
                {
                    result = current;

                    if (previous == null)
                    {
                        first = current.next;
                        if (first == null)
                            last = null;
                    }

                    if (previous != null)
                        previous.next = current.next;

                    if (current.next == null)
                        last = previous;

                }
                previous = current;
                current = current.next;
            }
            size--;

            if (result == null)
                return default(T);

            return result.value;
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


        public int Size
        {
            get { return this.size; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = first;
            while(current != null)
            {
                yield return current.value;
                current = current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}