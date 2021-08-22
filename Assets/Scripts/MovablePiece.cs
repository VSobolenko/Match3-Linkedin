using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePiece : MonoBehaviour
{
    private GamePiece piece;
    private IEnumerator moveCorourine;

    private void Awake()
    {
        piece = GetComponent<GamePiece>();
    }

    public void Move(int newX, int newY, float time)
    {
        if(moveCorourine != null)
        {
            StopCoroutine(moveCorourine);
        }

        moveCorourine = MoveCorourine(newX, newY, time);
        StartCoroutine(moveCorourine);
    }
    private IEnumerator MoveCorourine(int newX, int newY, float time)
    {
        piece.X = newX;
        piece.Y = newY;

        Vector3 startPos = transform.position;
        Vector3 endPos = piece.Grids.GetWorldPosition(newX, newY);

        for (float t=0; t <= 1* time; t += Time.deltaTime)
        {
            piece.transform.position = Vector3.Lerp(startPos, endPos, t / time);
            yield return 0;
        }
        piece.transform.position = endPos;
    }
}
