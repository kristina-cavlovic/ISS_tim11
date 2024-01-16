using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZvukMotora : MonoBehaviour
{
    Rigidbody RB;
    public AudioSource EngineSource;
    public int BrzineTrajanje;
    public float PithBoost;
    public float PitchRange;

    float temp1;
    float temp2;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float Speed = RB.velocity.magnitude;
        temp1 = Speed / BrzineTrajanje;
        temp2 = (int) temp1;

        float razlika = temp1 - temp2;

        if(Speed == 0) EngineSource.volume = 0;

        EngineSource.pitch = Mathf.Lerp(EngineSource.pitch, (PitchRange * razlika) + PithBoost, 0.1f);
    }
}
