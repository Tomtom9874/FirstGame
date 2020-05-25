using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableDoorAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Open", false);
    }

    public void PlayOpenAnimation()
    {
        Debug.Log("Animated");
        _animator.SetBool("Open", true);
    }



}
