using System;
using System.Collections.Generic;

namespace Queues
{
    public class Queue
    {
        private List<int> _Data;
        public ulong Counter;
        public Queue()
        {
            _Data = new List<int>();					// 1
            Counter = 1;
        }

        public void Enqueue(int element)				// 1
        {
            _Data.Add(element);						// 1
            Counter += 2;
        }

        public int Dequeue()
        {
            if (IsEmpty())						// 2
                throw new NullReferenceException("Очередь пуста");	// 1
            int result = _Data[0];					// 2
            _Data.RemoveAt(0);						// 1
            Counter += 8;
            return result;						// 1
        }

        public int Peek()
        {
            if (IsEmpty())						// 2
                throw new NullReferenceException("Очередь пуста");	// 1
            Counter += 6;
            return _Data[0];						// 2
        }


        public void Clear()
        {
            _Data.Clear();						// 1
            Counter = 0;
        }

        public int Get(int position)					// 1
        {
            if (position < 0 || position > Count)			// 3
                throw new IndexOutOfRangeException("Выход за пределы массива"); // 1
            Counter += 6;
            for (int i = 0; i < position; ++i)
            {				// 2
                Enqueue(Dequeue());                 // 2 + 2
                Counter += 4;
            }

            int val = Peek();                       // 2
            Counter += 2;
            for (int i = position; i < Count; ++i)
            {			// 2
                Enqueue(Dequeue());                 // 2 + 2
                Counter += 4;
            }
            Counter += 1;
            return val;							// 1
        }

        public void Set(int position, int value)			// 2
        {
            if (position < 0 || position > Count)			// 3
                throw new IndexOutOfRangeException("Выход за пределы массива"); // 1
            Counter += 7;
            for (int i = 0; i < position; ++i)
            {				// 2
                Enqueue(Dequeue());                 // 2 + 2
                Counter += 4;
            }

            _Data[0] = value;                       // 2
            Counter += 4;
            for (int i = position; i < Count; ++i)
            {			// 2
                Enqueue(Dequeue());                 // 2 + 2
                Counter += 4;
            }
        }

        public bool IsEmpty() => Count == 0;                    // 2

        public int Count
        {
            get => _Data.Count;							// 2
        }

        /// <summary>
        /// Перегрузка квадратных скобок
        /// </summary>
        /// <param name="position"></param>
        public int this[int position]						// 1
        {
            get => Get(position);						// 2
            set => Set(position, value);					// 1
        }

        public void Swap(int i, int j)						// 2
        {
            int temp = Get(i);							// 2
            Set(i, Get(j));							// 2
            Set(j, temp);							// 1
            Counter += 7;
        }

        public void Print()
        {
            for (int i = 0; i < Count; ++i)
                Console.Write(_Data[i] + " ");
            Console.Write("\n");
        }
    }

    public class Sort : Queue
    {
        private int Partition(int start, int end, int p)		// 3
        {
            int x = Get((start + end) / 2);				// 4
            int i = start;						// 1
            int j = end;						// 1
            Counter += 10;
            while (i <= j)						// 1
            {
                while (Get(j) > x)
                {
                    --j;                    // 2 + 1
                    Counter += 3;
                }
                while (Get(i) < x)
                {
                    ++i;                    // 2 + 1
                    Counter += 3;
                }
                if (i >= j)						// 1
                    break;						// 1
                Swap(i++, j--);						// 3
                Counter += 4;
            }
            Counter += 1;
            return j;							// 1

        }

        public int FindPivot(int i, int j, int k)			// 3
        {
            Counter += 3;
            if (Get(i) > Get(j))					// 3
            {
                Counter += 3;
                if (Get(k) > Get(i))
                {
                    Counter += 4;
                    return i;               // 3 // 4
                }
                Counter += 7;
                return Get(j) > Get(k) ? j : k;				// 4
            }
            Counter += 3;
            if (Get(k) > Get(j))
            {
                Counter += 4;				// 3
                return j;                       // 4
               
            }
            Counter += 4;
            return Get(i) > Get(k) ? i : k;				// 4
        }

        public void QuickSort(int start, int end)			// 2
        {
            Counter += 2;
            if (start < end)						// 1
            {
                Counter += 1;
                int p = FindPivot(start, (start + end) / 2, end);   // 4
                Counter += 4;
                Swap(p, (start + end) / 2);             // 3
                Counter += 3;
                int q = Partition(start, end, p);           // 2
                Counter += 4;
                QuickSort(start, q);					// 1
                QuickSort(q + 1, end);					// 1
            }
        }

    }
}