using UnityEngine;
using System.Collections;
public class FPSTarget : MonoBehaviour
{ 

    public int target = 30;

    void Awake()
    {
        Application.targetFrameRate = target;
    }

    void Update()
    {
        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }
}