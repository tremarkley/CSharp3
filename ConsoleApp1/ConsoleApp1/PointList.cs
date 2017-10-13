using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PointList : IList<Point>
    {
        private List<Point> _Points = new List<Point>();

        public Point this[int index]
        {
            get
            {
                return _Points[index];
            }
            set
            {
                _Points[index] = value;
                Changed?.Invoke(this, new
                PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Update));
            }
        }

        public int Count {
            get
            {
                return _Points.Count;
            }
        }

        bool ICollection<Point>.IsReadOnly {
            get
            {
                ICollection<Point> temp = _Points as ICollection<Point>;
                return temp.IsReadOnly;
            }
        }
        

        public event EventHandler<PointListChangedEventArgs> Changed;

        public void Add(Point item)
        {
            _Points.Add(item);
            Changed?.Invoke(this, new PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Add));
        }

        public void Clear()
        {
            _Points.Clear();
            Changed?.Invoke(this, new PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Clear));
        }

        public bool Contains(Point item)
        {
            return _Points.Contains(item);
        }

        public void CopyTo(Point[] array, int arrayIndex)
        {
            _Points.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return _Points.GetEnumerator();
        }

        public int IndexOf(Point item)
        {
            return _Points.IndexOf(item);
        }

        public void Insert(int index, Point item)
        {
            _Points.Insert(index, item);
            Changed?.Invoke(this, new PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Insert));
        }

        public bool Remove(Point item)
        {
            Changed?.Invoke(this, new PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Remove));
            return _Points.Remove(item);
        }

        public void RemoveAt(int index)
        {
            Changed?.Invoke(this, new PointListChangedEventArgs(PointListChangedEventArgs.PointListChangedOperations.Remove));
            _Points.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return _Points.GetEnumerator();
        }
    }
}
