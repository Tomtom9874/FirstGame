using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroy : MonoBehaviour
{
    private Vector2 _position;
    public Vector2 Position{get{return _position;}}
    private void Awake()
    {
        _position = GetComponent<Transform>().position;
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
        GlobalPlayerController.SetDestroy(_position, true);
    }
}
