using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puyo : MonoBehaviour {

    public enum PuyoColor
    {
        Red,
        Blue,
        Green,
        Yellow,
    }

    private PuyoColor _color;

    public PuyoColor Color
    {
        get { return _color; }
    }

    public Puyo Initialize(PuyoColor color)
    {
        _color = color;
        var material = GetComponent<Renderer>().material;
        switch (_color)
        {
            case PuyoColor.Red:
                material.color = UnityEngine.Color.red;
                break;
            case PuyoColor.Blue:
                material.color = UnityEngine.Color.blue;
                break;
            case PuyoColor.Green:
                material.color = UnityEngine.Color.green;
                break;
            case PuyoColor.Yellow:
                material.color = UnityEngine.Color.yellow;
                break;
        }
        return this;
    }

    public void Bright()
    {

    }

    public void Vanish()
    {

    }
}
