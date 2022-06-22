using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private KeyCode keycodeUp;
    [SerializeField] private KeyCode keycodeDown;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keycodeUp))
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        
        else if (Input.GetKey(keycodeDown))
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
    }
}
