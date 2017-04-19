using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unit = UniRx.Unit;

namespace Assets.Scripts
{
    public class PuyosEffector : MonoBehaviour
    {
        private Queue<Action<Unit>> _effectQueue;
        public PuyosEffector Initialize(PuyosCollection puyos)
        {
            _effectQueue = new Queue<Action<Unit>>();
            foreach (var puyo in puyos)
            {
                puyo.OnEffect.Subscribe(_effectQueue.Enqueue);
            }
            StartCoroutine(EffectCoroutine());
            return this;
        }

        private IEnumerator EffectCoroutine()
        {
            while (true)
            {
                if (_effectQueue.Count > 0)
                {
                    var effect = _effectQueue.Dequeue();
                    effect(Unit.Default);
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
