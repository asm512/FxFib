using System;

namespace FxFibonacci
{
    public class FxFib
    {
        private double _anchor0;
        private double _anchor1;
        private int _dPlaces;
        private bool _inverseDir = false;

        private static readonly double[] _stdSeq =
        {
            23.6,
            38.2,
            50,
            61.8,
            78.6
        };

        public readonly double[] StandardSequence;

        public FxFib(double _anc0, double _anc1, bool _calculateDefSeq = false, int _decimalPlaces = -1)
        {
            this._anchor0 = _anc0;
            this._anchor1 = _anc1;
            if (_decimalPlaces != -1) { this._dPlaces = _decimalPlaces; }
            else { this._dPlaces = BitConverter.GetBytes(decimal.GetBits(Convert.ToDecimal(_anc0))[3])[2]; }
            if (_anc1 < _anc0) { _inverseDir = true; }
            if (_calculateDefSeq) { StandardSequence = Calculate(_stdSeq); }
        }

        public double Calculate(double _fibLevel)
        {
            return _cPercentage(_fibLevel);
        }

        public double[] Calculate(double[] _fibLevels)
        {
            var _calculatedLevels = new double[_fibLevels.Length];
            for (int i = 0; i < _fibLevels.Length; i++)
            {
                _calculatedLevels[i] = _cPercentage(_fibLevels[i]);
            }
            return _calculatedLevels;
        }

        private double _cPercentage(double _p)
        {
            double _diff;
            double _resBare;
            if (!_inverseDir) { _diff = _anchor0 - _anchor1; _resBare = _anchor1; }
            else { _diff = _anchor1 - _anchor0; _resBare = _anchor0; }
            return Math.Round(((_diff / 100) * _p) + _resBare, _dPlaces);
        }

    }
}
