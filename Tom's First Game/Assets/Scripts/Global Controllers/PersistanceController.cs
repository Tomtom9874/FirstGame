using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistanceController : MonoBehaviour
{
    void Start()
    {
        GlobalPlayerController.ReDestroyObjects();
    }
}