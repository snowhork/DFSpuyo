using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PuyosCollection : IEnumerable<Puyo>
    {
        private Puyo[,] _puyos;
        private Puyo[] _puyoPrefs;
        private const int XSize = 6;
        private const int YSize = 6;

        public PuyosCollection(Puyo[] puyoPrefs)
        {
            _puyoPrefs = puyoPrefs;
            LoadPuyos();
            SetPuyos();
        }

        private void LoadPuyos()
        {
            _puyos = new Puyo[,]
            {
                {p(1), p(1), p(-1), p(0), p(0), p(1)},
                {p(1), p(2), p(-1), p(1), p(2), p(1)},
                {p(1), p(1), p(-1), p(3), p(3), p(3)},
                {p(1), p(-1), p(-1), p(1), p(0), p(3)},
                {p(-1), p(0), p(1), p(2), p(0), p(3)},
                {p(0), p(0), p(2), p(-1), p(0), p(0)},
            };
        }

        private Puyo p(int n)
        {
            if (n == -1) return null;
            var puyo = Object.Instantiate(_puyoPrefs[n]);
            puyo.Color = (Puyo.PuyoColor) n;
            return puyo;
        }

        private void SetPuyos()
        {
            for (var x = 0; x < XSize; x++)
            for (var y = 0; y < YSize; y++)
            {
                if(_puyos[x, y] == null) continue;
                _puyos[x, y].Initialize(x, y);
                _puyos[x, y].transform.position = new Vector3(y, (XSize - x), 0);
            }

        }

        public IEnumerator<Puyo> GetEnumerator()
        {
            for (var x = 0; x < XSize; x++)
            for (var y = 0; y < YSize; y++)
            {
                if(_puyos[x, y] == null) continue;
                yield return _puyos[x, y];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
