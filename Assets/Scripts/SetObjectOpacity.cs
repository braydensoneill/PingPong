using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectOpacity : MonoBehaviour
{
    [SerializeField] private Material thisMaterial;
    [SerializeField] private int opacity;

    // Start is called before the first frame update
    void Start()
    {
        Color color = thisMaterial.color;
        color.a = opacity;

        thisMaterial.color = color;
    }
}
