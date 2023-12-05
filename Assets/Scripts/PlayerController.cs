using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");


        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

    }
}
