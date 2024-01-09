using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

/*public class PlayerController : MonoBehaviour
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
}*/

public class PlayerController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;
    [SerializeField] Transform wheelTransform;

    public float engineForce = 500f;
    public float breakForce = 1200f;
    public float maxTurnAngle = 30f;
    public float turnAngleStep = 2f;
    public Text info;

    private float currEngine = 0f;
    private float currBreak = 0f;
    private float currTurn = 0f;

    private void FixedUpdate()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.C))
        {
            if((transform.InverseTransformDirection(rb.velocity).z < 0) && rb.velocity.magnitude > 1 && !Input.GetKey(KeyCode.Space)) {
                currBreak = 1000;
                currEngine = 0;
            } else
            {
                currEngine = engineForce;
                currBreak = 0;
            }
            
        } else if (Input.GetKey(KeyCode.X))
        {
            currBreak = breakForce;
            currEngine = 0;
        } else
        {
            currEngine = 0;
            currBreak = 100;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if((transform.InverseTransformDirection(rb.velocity).z > 0) && rb.velocity.magnitude > 1)
            {
                currBreak = 1000;
            } else
            {
                currEngine = -currEngine;
            }
        }

        currTurn = maxTurnAngle * Input.GetAxis("Horizontal");

        frontRight.motorTorque = currEngine;
        frontLeft.motorTorque = currEngine;
        
        
        frontRight.brakeTorque = currBreak;
        frontLeft.brakeTorque = currBreak;
        backRight.brakeTorque = currBreak;
        backLeft.brakeTorque = currBreak;

        frontRight.steerAngle = currTurn;
        frontLeft.steerAngle = currTurn;

        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
        UpdateWheel(backRight, backRightTransform);

        

       
       

        string s = "" + (Mathf.Round(rb.velocity.magnitude*3.2f));
        info.text = s;

    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);


        trans.position = position;
        trans.rotation = rotation;
    }
}
