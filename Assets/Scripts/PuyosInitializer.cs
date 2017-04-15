using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts
{
    public class PuyosInitializer
    {
        private Puyo _puyo;
        private const int XSize = 6;
        private const int YSize = 6;

        public PuyosInitializer(Puyo puyo, out Puyo[,] puyos)
        {
            _puyo = puyo;
            LoadPuyos(out puyos);
            SetPuyos(puyos);
        }

        private void LoadPuyos(out Puyo[,] puyos)
        {
            puyos = new Puyo[,]
            {
                {p(-1), p(-1), p(0), p(0), p(0), p(1)},
                {p(-1), p(-1), p(0), p(0), p(0), p(1)},
                {p(1), p(-1), p(0), p(0), p(2), p(1)},
                {p(-1), p(-1), p(0), p(0), p(3), p(1)},
                {p(-1), p(-1), p(0), p(1), p(0), p(1)},
                {p(-1), p(1), p(0), p(0), p(0), p(1)},
            };
        }

        private Puyo p(int n)
        {
            if (n == -1) return null;
            return Object.Instantiate(_puyo).Initialize((Puyo.PuyoColor) n);
        }

        private void SetPuyos(Puyo[,] puyos)
        {

            for (var x = 0; x < XSize; x++)
            for (var y = 0; y < YSize; y++)
            {
                if(puyos[x, y] == null) continue;
                puyos[x, y].transform.position = new Vector3(
                    y,
                    (XSize - x),
                    0);
            }

        }


    }
}
