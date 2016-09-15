using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalindromeCommon;

namespace Palindromes.DescendingMultiples
{
    public class DescendingMultipleSupplier : AbstractValueSupplier<long>
    {
        private readonly long _minFactor;
        private readonly IBestIndexFinder<long> _indexFinder;
        private long _lowestLeftSoFar;
        private List<Tuple<long, long>> _candidatePairs = new List<Tuple<long, long>>();

        public override long NextValue
        {
            get
            {
                return GetNextMultiple();
            }
        }

        public DescendingMultipleSupplier(int numDigits) : this((int)Math.Pow(10, numDigits - 1), (int)Math.Pow(10, numDigits) - 1)
        { }

        public DescendingMultipleSupplier(int min, int max) : this(min, max, new BestIndexFinder<long>((x, y) => x > y)) { }

        public DescendingMultipleSupplier(int min, int max, IBestIndexFinder<long> indexFinder)
        {
            _minFactor = min;
            _lowestLeftSoFar = max + 1;
            _indexFinder = indexFinder;
        }

        public override bool HasNext()
        {
            return _lowestLeftSoFar > _minFactor || _candidatePairs.Count > 0;
        }

        private long GetNextMultiple()
        {
            // Candidates are:
            //   - Previously seen leftFactor, with decremented rightFactor, as long as rightFactor
            //     stays equal to or greater than minFactor
            //   - Decrement lowestLeftSoFar, set both leftFactor and rightFactor equal to the new
            //     lowestLeftSoFar, as long as it stays equal to or greater than minFactor
            var candidateValues = _candidatePairs.Select(x => x.Item1 * x.Item2);
            if (_lowestLeftSoFar > _minFactor)
            {
                candidateValues = candidateValues.Concat(new long[] { (_lowestLeftSoFar - 1) * (_lowestLeftSoFar - 1) });
            }

            int bestIndex = _indexFinder.FindIndex(candidateValues);

            if (bestIndex == _candidatePairs.Count)
            {
                // Best option is not already in candidatePairs. Decrement lowestLeftSoFar and
                // add the option.
                DecrementLowestLeft();
            }

            // Grab the best item
            long leftFactor = _candidatePairs[bestIndex].Item1;
            long rightFactor = _candidatePairs[bestIndex].Item2;

            // Decrement the rightFactor for the next time around.
            DecrementRightFactorAtCandidateIndex(bestIndex);

            return leftFactor * rightFactor;
        }

        private void DecrementRightFactorAtCandidateIndex(int idx)
        {
            // If rightFactor will stay greater than or equal to minFactor, decrement it.
            // Otherwise, remove the leftFactor/rightFactor pair from the candidates.
            long leftFactor = _candidatePairs[idx].Item1;
            long rightFactor = _candidatePairs[idx].Item2;
            long newRightFactor = rightFactor - 1;
            if (newRightFactor >= _minFactor)
            {
                _candidatePairs[idx] = new Tuple<long, long>(leftFactor, newRightFactor);
            }
            else
            {
                _candidatePairs.RemoveAt(idx);
            }
        }

        private void DecrementLowestLeft()
        {
            // When decrementing the lowest left seen so far, we need to add a new option
            // to the candidates.
            _lowestLeftSoFar -= 1;
            _candidatePairs.Add(new Tuple<long, long>(_lowestLeftSoFar, _lowestLeftSoFar));
        }
    }
}
