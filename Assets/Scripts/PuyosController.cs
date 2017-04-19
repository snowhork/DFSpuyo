using System.Collections.Generic;
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
            var flags = new bool[PuyosCollection.XSize, PuyosCollection.YSize]; // C#のboolの初期値はfalseです。これが訪れたか否かのフラグになります。
            var queue = new Queue<Puyo>();
            foreach (var puyo in _puyos) //_puyosをforeachしたときは、puyoはnullにならない仕様です
            {
                if(flags[puyo.X, puyo.Y]) continue; //既に訪れていればスキップします。
                WFS(puyo.X, puyo.Y, flags, queue); //訪れていないので探索を始めます。
                foreach (var puyo2 in queue)
                {
                    if(flags[puyo2.X, puyo2.Y]) continue; //既に訪れていればスキップします。
                    WFS(puyo2.X, puyo2.Y, flags, queue); //訪れていないので探索を始めます。
                }
            }
        }

        private void WFS(int x, int y, bool[,] flags, Queue<Puyo> queue)
        {
            // この実装では、(x,y)のぷよはnullでないことを前提としています。
            flags[x, y] = true; // 訪れたフラグを立てる
            _puyos.Get(x, y).Bright(); // その地点のぷよを光らせる
            queue.Enqueue(_puyos.Get(x, y));
            Puyo puyo;

            // 1.周囲のpuyoを一個とって
            // 2.そのpuyoがnullでないかつ、まだ訪れていないのならば、そこを探索する

            puyo = _puyos.Get(x + 1, y);
            if(puyo != null && !flags[puyo.X, puyo.Y]) queue.Enqueue(puyo);

            puyo = _puyos.Get(x - 1, y);
            if(puyo != null && !flags[puyo.X, puyo.Y]) queue.Enqueue(puyo);

            puyo = _puyos.Get(x, y + 1);
            if(puyo != null && !flags[puyo.X, puyo.Y]) queue.Enqueue(puyo);

            puyo = _puyos.Get(x, y - 1);
            if(puyo != null && !flags[puyo.X, puyo.Y]) queue.Enqueue(puyo);

            var next = queue.Dequeue();
        }
    }
}
