using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInternals
{
    public class TempTracker
    {
        private const int MaxTemp = 111;
        private const int MinTemp = 0;
        private double _mean;
        private int _mode;
        private int _max;
        private int _min;
        private int _count;
        private int _total;
        private int[] _tempCounts = new int[MaxTemp];
        private int _maxOccurrences;

        public TempTracker()
        {
        }

        public void Insert(int temp)
        {
            if (temp >= MaxTemp || temp < MinTemp) return;
            this._count++;
            this._max = Math.Max(temp, this._max);
            this._min = Math.Min(temp, this._min);
            this._total += temp;
            this._mean = (double)this._total / this._count;
            _tempCounts[temp]++;
            if (_tempCounts[temp] > this._maxOccurrences)
            {
                _mode = temp;
                _maxOccurrences = _tempCounts[temp];
            }

        }

        public int GetMode()
        {
            return this._mode;
        }

        public int GetMin()
        {
            return this._min;
        }

        public int GetMax()
        {
            return this._max;
        }

        public double GetMean()
        {
            return this._mean;
        }
    }
}
