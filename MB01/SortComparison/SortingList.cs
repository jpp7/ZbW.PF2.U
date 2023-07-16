using System;
using System.Collections;
using System.Collections.Generic;

namespace MB01.SortComparison
{
    public delegate void HighlightingEventHandler(object source, HighlightingEventArgs e);

    public class HighlightingEventArgs : EventArgs
    {
        public HighlightingEventArgs(int index)
        {
            Index = index;
        }

        public int Index { get; }
    }

    public class SortingList : IList<int>
    {
        public event HighlightingEventHandler OnHighlighting;
        private bool highlightingBlocked;
        private readonly List<int> list;
        public int IndexOf(int item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, int item)
        {
            list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public int this[int index]
        {
            get
            {
                if (!highlightingBlocked)
                {
                    OnHighlighting?.Invoke(this, new HighlightingEventArgs(index));
                }
                return list[index];
            }
            set
            {
                if (!highlightingBlocked)
                {
                    OnHighlighting?.Invoke(this, new HighlightingEventArgs(index));
                }
                list[index] = value;
            }
        }

        public SortingList()
        {
            list = new List<int>();
        }
        public SortingList(IEnumerable<int> c)
        {
            list = new List<int>(c);
        }
        public SortingList(int capacity)
        {
            list = new List<int>(capacity);
        }

        public object Clone()
        {
            var ret = new SortingList(this);
            return ret;
        }

        public HighlightingBlocker BlockHighlighting()
        {
            return new HighlightingBlocker(this);
        }

        public class HighlightingBlocker : IDisposable
        {
            private readonly SortingList list;
            public HighlightingBlocker(SortingList list)
            {
                this.list = list;
                this.list.highlightingBlocked = true;
            }


            public void Dispose()
            {
                list.highlightingBlocked = false;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(int item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(int item)
        {
            return list.Contains(item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(int item)
        {
            return list.Remove(item);
        }

        public int Count => list.Count;
        public bool IsReadOnly => false;

        public int Capacity => list.Capacity;

        public void Sort()
        {
            list.Sort();
        }

        public void Reverse()
        {
            list.Reverse();
        }
    }
}
