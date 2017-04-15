using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Puyo[] _puyoPrefs;
        [SerializeField] private PuyosEffector _effector;

        private void Start()
        {
            var puyos = new PuyosCollection(_puyoPrefs);
            var controller = new PuyosController(puyos);
            var effector = Instantiate(_effector).Initialize(puyos);

            Observable.Return(Unit.Default)
                .Delay(TimeSpan.FromSeconds(2))
                .Subscribe(_ => controller.Execute());
        }
    }
}
