using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    public class DynamicArray<T> : IDisposable, IEnumerable<T> where T : new()
    {
        #region Fields
        private bool _Disposed = false;
        private T[] _Items;
        #endregion

        #region Properties
       public T this[int index]
        {
            get {
                /*if (index > 0 && index <= _Items.Length - 1)
                {
                    return _Items[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }*/
                return _Items[index];
            }
            set {
                /*if (index > 0 && index <= _Items.Length - 1)
                {
                    _Items[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }*/
                _Items[index] = value;
            }
        }
        #endregion

        #region Constructors
        public DynamicArray(int size)
        {
            _Items = new T[size];
            Console.WriteLine($"Creating DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        }

        public DynamicArray(IEnumerable<T> items)
        {
            _Items = items.ToArray();
            Console.WriteLine($"Creating DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        }
        #endregion

        #region Methods
        public void Resize(int size)
        {
            T[] items = new T[size];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new T();
            }
            for (int i = 0; i < items.Length && i < _Items.Length; i++)
            {
                items[i] = _Items[i];
            }
            _Items = items;
        }
        #endregion

        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return (_Items as IEnumerable<T>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Items.GetEnumerator();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Console.WriteLine($"Disposing DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed)
            {
                return;
            }
            if (disposing)
            {
                _Items = null;
            }
            _Disposed = true;
        }

        ~DynamicArray()
        {
            Console.WriteLine($"Finalizing DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        }
        #endregion
    }
}
