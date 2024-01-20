using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRollBarFront : MonoBehaviour
{
    [SerializeField] WheelCollider WheelR;
    [SerializeField] WheelCollider WheelL;
    double AntiRoll = 5000.0;

    private void FixedUpdate()
    {
        WheelHit hit;
        var travelL = 1.0;
        var travelR = 1.0;

        var groundedL = WheelL.GetGroundHit(out hit);
        if (groundedL)
            travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;

         

        var groundedR = WheelR.GetGroundHit(out hit);
        if (groundedR)
            travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;

        var antiRollForce = (float)((travelL - travelR) * AntiRoll);

        if (groundedL)
            GetComponent<Rigidbody>().AddForceAtPosition(WheelL.transform.up * -antiRollForce,
                   WheelL.transform.position);
        if (groundedR)
            GetComponent<Rigidbody>().AddForceAtPosition(WheelR.transform.up * antiRollForce,
                   WheelR.transform.position);
    }
}
