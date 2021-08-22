using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearablePriece : MonoBehaviour
{
    public AnimationClip clearAnimation;

    private bool isBeingCleared = false;    

    public bool IsBeingCleared
    {
        get => isBeingCleared;
    }

    protected GamePiece piece;

    private void Awake()
    {
        piece = GetComponent<GamePiece>();
    }

    public  void Clear()
    {
        isBeingCleared = true;
        StartCoroutine(ClearCoroutine());
    }
    private IEnumerator ClearCoroutine()
    {
        Animator animator = GetComponent<Animator>();

        if(animator)
        {
            animator.Play(clearAnimation.name);

            yield return new WaitForSeconds(clearAnimation.length);

            Destroy(gameObject);
        }
    }
}
