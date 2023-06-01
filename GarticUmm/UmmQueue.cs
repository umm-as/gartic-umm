using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UmmQueue;

namespace UmmQueue
{
    class Node<T>
    {
        public T value;
        public string present;
        public Node<T> next;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
            this.present = "";
        }
    }

    class PersonQueue<T> : IEnumerable<T>
    {
        private Node<T> first;
        private Node<T> last;
        private int size;

        public PersonQueue()
        {
            this.first = null;
            this.last = null;
            size = 0;
        }

        public T Peek()
        {
            if (first == null)
                return default(T);

            return first.value;
        }

        public void Enqueue(T item)
        {
            Node<T> newnode = new Node<T>(item);
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

        public T Dequeue()
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

        public T Pop(T target)
        {
            if (first == null)
                return default(T);

            Node<T> previous = null;
            Node<T> current = first;
            Node<T> result = null;

            while (current != null)
            {
                if (current.value.Equals(target))
                {
                    result = current;

                    if (previous == null)
                    {
                        first = current.next;
                        if (first == null)
                        {
                            last = null;
                        }
                    }

                    if (previous != null)
                    {
                        previous.next = current.next;
                    }

                    if (current.next == null)
                    {
                        last = previous;
                    }

                }
                previous = current;
                current = current.next;
            }

            if (result == null)
                return default(T);

            size--;
            return result.value;
        }

        public int GetIndexOf(T target)
        {
            Node<T> cursor = first;
            int idx = 0;

            while (cursor != null)
            {
                if (cursor.value.Equals(target))
                {
                    return idx;
                }
                cursor = cursor.next;
                idx++;
            }

            return -1;
        }

        public T GetNextItemOf(T target)
        {
            Node<T> cursor = first;

            if (first == null)
                return default(T);

            while (cursor != null)
            {
                if (cursor.value.Equals(target))
                {
                    // 끝까지 도달했으면 맨 앞의 값 반환 (Circular queue)
                    if (cursor.next == null)
                    {
                        return first.value;
                    }
                    return cursor.next.value;
                }
                cursor = cursor.next;
            }

            return default(T);
        }

        public void SetPresent(T target, string present)
        {
            Node<T> cursor = first;

            if (first == null) return;

            while (cursor != null)
            {
                if (cursor.value.Equals(target))
                {
                    cursor.present = present;
                    return;
                }
                cursor = cursor.next;
            }
        }

        public T GetPresentor(string present)
        {
            Node<T> cursor = first;

            if (first == null)
                return default(T);

            while (cursor != null)
            {
                if (cursor.present == present)
                {
                    return cursor.value;
                }
                cursor = cursor.next;
            }

            return default(T);
        }

        private Node<T> GetReverseNthNode(Node<T> from, int idx)
        {
            Node<T> cursor = from;

            for (int i=0; i<size-idx; i++)
            {
                cursor = cursor.next;
                if (cursor == null)
                {
                    cursor = first;
                }
            }

            return cursor;
        }

        public string GetPresentSavepointKey(T target, int turn)
        {
            Node<T> cursor = first;

            while (cursor != null)
            {
                if (cursor.value.Equals(target))
                {
                    break;
                }
                cursor = cursor.next;
            }

            cursor = GetReverseNthNode(cursor, turn);

            return cursor.present;
        }

        public T GetNthItem(T target, int idx)
        {
            Node<T> cursor = first;

            while (cursor != null)
            {
                if (cursor.value.Equals(target))
                {
                    break;
                }
                cursor = cursor.next;
            }

            for (int i=0; i<idx; i++)
            {
                cursor = cursor.next;
                if (cursor == null)
                {
                    cursor = first;
                }
            }

            return cursor.value;
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