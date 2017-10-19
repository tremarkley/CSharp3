using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    public class Student : IDisposable
    {
        #region Fields
        private bool _Disposed = false;
        #endregion

        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DynamicArray<int> Scores { get; set; }
        #endregion

        #region Constructors
        public Student(string lastName, string firstName, int numScores)
        {
            LastName = lastName;
            FirstName = firstName;
            Scores = new DynamicArray<int>(numScores);
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Last Name: {LastName, -15} First Name: {FirstName, -10} Number of Scores: {Scores.Count(), -5} Avg Score: {AvgScore(): 0.000}"; 
        }

        private double AvgScore()
        {
            double total = 0;
            foreach (int score in Scores)
            {
                total += score;
            }
            if (Scores.Count() > 0)
            {
                return total / Scores.Count();
            }
            else return 0;
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            Console.WriteLine($"Disposing Student from thread {Thread.CurrentThread.ManagedThreadId}");
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
                Scores?.Dispose();
                Scores = null;
            }
            _Disposed = true;
        }

        ~Student()
        {
            Console.WriteLine($"Finalizing Student from thread {Thread.CurrentThread.ManagedThreadId}");
        }
        #endregion
    }
}
