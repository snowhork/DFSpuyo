using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Puyo _puyo;
        private Puyo[,] _puyos;
        private void Start()
        {
            var initializer = new PuyosInitializer(_puyo, out _puyos);
            var vanisher = new PuyoVanisher(_puyos);

            Observable.Return(Unit.Default)
                .Delay(TimeSpan.FromSeconds(2))
                .Subscribe(_ => vanisher.Execute());
        }
    }
}
