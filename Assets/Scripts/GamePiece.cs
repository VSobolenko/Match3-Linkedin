using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    private int _x;
    private int _y;

    public int X
    {
        get { return _x; }
        set
        {
            if (IsMovable())
            {
                _x = value;
            }
        }
    }
    public int Y
    {
        get { return _y; }
        set
        {
            if (IsMovable())
            {
                _y = value;
            }
        }
    }

    private Grids.PieceType _type;
    public Grids.PieceType Type
    {
        get { return _type; }
        set
        {
        }
    }

    private Grids _grids;
    public Grids Grids
    {
        get { return _grids; }
        set
        {
        }
    }

    private MovablePiece movableComponent;
    public MovablePiece MovableComponent
    {
        get { return movableComponent; }
    }

    private ColorPiece colorComponent;
    public ColorPiece ColorComponent
    {
        get { return colorComponent; }
    }

    private void Awake()
    {
        movableComponent = GetComponent<MovablePiece>();
        colorComponent = GetComponent<ColorPiece>();
    }
    public void Init(int x, int y, Grids grids, Grids.PieceType type)
    {
        _x = x;
        _y = y;
        _grids = grids;
        _type = type;
    }

    public bool IsMovable()
    {
        return movableComponent != null;
    }

    public bool IsColored()
    {
        return colorComponent != null;
    }
}
