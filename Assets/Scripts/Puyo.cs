using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Puyo : MonoBehaviour
{
    private Subject<Action<Unit>> _effectSubject;
    private PuyoColor _color;
    private int _x;
    private int _y;

    public int X
    {
        get { return _x; }
    }

    public int Y
    {
        get { return _y; }
    }

    public IObservable<Action<Unit>> OnEffect
    {
        get { return _effectSubject; }
    }

    private void Awake()
    {
        _effectSubject = new Subject<Action<Unit>>();
    }

    public enum PuyoColor
    {
        Red,
        Blue,
        Green,
        Yellow,
    }

    public PuyoColor Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public Puyo Initialize(int x, int y)
    {
        _x = x;
        _y = y;
        return this;
    }

    public void Bright()
    {
        _effectSubject.OnNext(_ =>
        {
            var flare = GetComponent("LensFlare") as Behaviour;
            flare.enabled = true;
        });
    }

    public void Vanish()
    {
        _effectSubject.OnNext(_ =>
        {
            Destroy(this.gameObject);
        });

    }
}
