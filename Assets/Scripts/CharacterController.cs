using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private KeyCode keycodeUp;
    [SerializeField] private KeyCode keycodeDown;

    [SerializeField] private float zBoundaryMax;
    [SerializeField] private float zBoundaryMin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keycodeUp))
            MoveUp();

        else if (Input.GetKey(keycodeDown))
            MoveDown();  
    }

    public void MoveUp()
    {
        if(transform.position.z < zBoundaryMax)
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
    }

    public void MoveDown()
    {
        if (transform.position.z > zBoundaryMin)
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
    }
}
