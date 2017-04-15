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
            foreach (var puyo in _puyos) //_puyosをforeachしたときは、puyoはnullにならない仕様です
            {
                var list = new List<Puyo>(); //同じ色のぷよを追加していくためのリストを用意します。
                if(flags[puyo.X, puyo.Y]) continue; //既に訪れていればスキップします。
                DFS(puyo.X, puyo.Y, flags, list); //訪れていないので探索を始めます。

                if(list.Count < 4) continue; // listの大きさが４以上であれば、
                foreach (var puyo2 in list) // list内のpuyoを全て消す。
                {
                    puyo2.Vanish();
                }

            }
        }

        private void DFS(int x, int y, bool[,] flags, List<Puyo> list)
        {
            // この実装では、(x,y)のぷよはnullでないことを前提としています。
            flags[x, y] = true; // 訪れたフラグを立てる
            _puyos.Get(x, y).Bright(); // その地点のぷよを光らせる
            list.Add(_puyos.Get(x, y)); // 探索した同じ色のぷよを追加します。
            var color = _puyos.Get(x, y).Color;
            Puyo puyo;

            // 1.周囲のpuyoを一個とって
            // 2.そのpuyoがnullでないかつ、まだ訪れていないのならば、そこを探索する
            // 探索する条件に、色が同じかを追加する。

            puyo = _puyos.Get(x + 1, y);
            if(puyo != null && !flags[puyo.X, puyo.Y] && color == puyo.Color) DFS(puyo.X, puyo.Y, flags, list);

            puyo = _puyos.Get(x - 1, y);
            if(puyo != null && !flags[puyo.X, puyo.Y] && color == puyo.Color) DFS(puyo.X, puyo.Y, flags, list);

            puyo = _puyos.Get(x, y + 1);
            if(puyo != null && !flags[puyo.X, puyo.Y] && color == puyo.Color) DFS(puyo.X, puyo.Y, flags, list);

            puyo = _puyos.Get(x, y - 1);
            if(puyo != null && !flags[puyo.X, puyo.Y] && color == puyo.Color) DFS(puyo.X, puyo.Y, flags, list);
        }
    }
}
