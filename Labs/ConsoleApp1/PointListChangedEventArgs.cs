using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class PointListChangedEventArgs : EventArgs
    {
        public enum PointListChangedOperations
        {
            Unknown,
            Add,
            Remove,
            Insert,
            Clear,
            Update
        }

        public PointListChangedOperations Operation { get; set; }

        public PointListChangedEventArgs(PointListChangedOperations operation)
        {
            Operation = operation;
        }
    }
}
