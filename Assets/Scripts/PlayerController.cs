using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
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
    /*public enum myLocation
    {
        raskrizje,
        sredinaPlanine,
        planinaKraj,
        gradUlica
    }*/
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] PhysicMaterial terrainMaterial;

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

    /*[SerializeField]
    public myLocation selectedLocation;*/

    private float currEngine = 0f;
    private float currBreak = 0f;
    private float currTurn = 0f;

    private void Start()
    {
        string path = Application.streamingAssetsPath;
        path = path + "/config.txt";
        string selectedLocation = File.ReadAllLines(path)[0];

        /*if (selectedLocation == myLocation.raskrizje) transform.SetPositionAndRotation(new Vector3((float)-14.89, 0, (float)-8.60000038), Quaternion.Euler(0f, 90f, 0f));
        else if (selectedLocation == myLocation.gradUlica) transform.SetPositionAndRotation(new Vector3(1f, 0, -121.199997f), Quaternion.Euler(0f, 0f, 0f));
        else if (selectedLocation == myLocation.sredinaPlanine) transform.SetPositionAndRotation(new Vector3(791.528442f, 7.04993773f, -338.137115f), Quaternion.Euler(356.311798f, 123.236107f, 1.41131294f));
        else if (selectedLocation == myLocation.planinaKraj) transform.SetPositionAndRotation(new Vector3(1016, 1.60000002f, 432), Quaternion.Euler(0f, 80f, 0f));
        */
        if (selectedLocation.Equals("Raskrizje")) transform.SetPositionAndRotation(new Vector3((float)-14.89, 0, (float)-8.60000038), Quaternion.Euler(0f, 90f, 0f));
        else if (selectedLocation.Equals("Grad Ulica")) transform.SetPositionAndRotation(new Vector3(1f, 0, -121.199997f), Quaternion.Euler(0f, 0f, 0f));
        else if (selectedLocation.Equals("Sredina Planine")) transform.SetPositionAndRotation(new Vector3(791.528442f, 7.04993773f, -338.137115f), Quaternion.Euler(356.311798f, 123.236107f, 1.41131294f));
        else if (selectedLocation.Equals("Planina Kraj")) transform.SetPositionAndRotation(new Vector3(1016, 1.60000002f, 432), Quaternion.Euler(0f, 80f, 0f));

    }
    private void FixedUpdate()
    {
        WheelHit wh;

        frontRight.GetGroundHit(out wh);
       //Debug.Log((wh.collider.sharedMaterial == terrainMaterial));


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
                if (wh.collider.sharedMaterial == terrainMaterial) currEngine = currEngine / 2;
            }
            
        } else if (Input.GetKey(KeyCode.X))
        {
            currBreak = breakForce;
            currEngine = 0;
        } else
        {
            currEngine = 0;
            currBreak = 100;
            if (wh.collider.sharedMaterial == terrainMaterial) currBreak = currBreak * 2 ;
        }

        

        if (Input.GetKey(KeyCode.Space))
        {
            if((transform.InverseTransformDirection(rb.velocity).z > 0) && rb.velocity.magnitude > 1)
            {
                currBreak = 1000;
            } else
            {
                currEngine = -currEngine;
                if (wh.collider.sharedMaterial == terrainMaterial) currEngine = currEngine / 2;
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
