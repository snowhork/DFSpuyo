using UnityEngine;

namespace Assets.Scripts
{
    public class PuyosController
    {
        PuyosCollection _puyos;

        public PuyosController(PuyosCollection puyos)
        {
            _puyos = puyos;
        }

        public void Execute()
        {
            var flags = new bool[PuyosCollection.XSize, PuyosCollection.YSize]; // C#のboolの初期値はfalseです。
            foreach (var puyo in _puyos)
            {
                if(flags[puyo.X, puyo.Y]) continue;
                DFS(puyo.X, puyo.Y, flags);
            }
        }

        private void DFS(int x, int y, bool[,] flags)
        {
            flags[x, y] = true;
            _puyos.Get(x, y).Bright();
            Puyo puyo;

            puyo = _puyos.Get(x + 1, y);
            if(puyo != null && !flags[puyo.X, puyo.Y]) DFS(puyo.X, puyo.Y, flags);

            puyo = _puyos.Get(x - 1, y);
            if(puyo != null && !flags[puyo.X, puyo.Y]) DFS(puyo.X, puyo.Y, flags);

            puyo = _puyos.Get(x, y + 1);
            if(puyo != null && !flags[puyo.X, puyo.Y]) DFS(puyo.X, puyo.Y, flags);

            puyo = _puyos.Get(x, y - 1);
            if(puyo != null && !flags[puyo.X, puyo.Y]) DFS(puyo.X, puyo.Y, flags);
        }
    }
}
