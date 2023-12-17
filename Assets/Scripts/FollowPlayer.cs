using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3((float)-0.1, (float)1.2, (float)-0.05);
    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            offset = new Vector3((float)-0.1, (float)1.2, (float)-0.05);
            transform.localRotation = Quaternion.identity;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            offset = new Vector3((float)0, (float)3.29, (float)-4);
            transform.localRotation = Quaternion.identity;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            offset = new Vector3((float)0, (float)3.29, (float)4);
            Vector3 rot = transform.localRotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y + 180, rot.z);
            transform.localRotation = Quaternion.Euler(rot);
        }
        transform.localPosition =  offset;
       
       
    }
}
