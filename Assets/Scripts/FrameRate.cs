using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    [SerializeField] private int frameRate;

    private void Awake()
    {
        Application.targetFrameRate  = frameRate;
    }
}
