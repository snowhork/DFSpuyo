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
            foreach (var puyo in _puyos)
            {
                puyo.Bright();
            }
        }
    }
}
