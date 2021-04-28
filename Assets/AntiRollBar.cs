using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRollBar : MonoBehaviour
{
    public WheelCollider wheel_left;
    public WheelCollider wheel_right;
    public float anti_roll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Fixedpdate()
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = wheel_left.GetGroundHit(out hit);
        if (groundedL)
        {
            travelL = (-wheel_left.transform.InverseTransformPoint(hit.point).y - wheel_left.radius) / wheel_left.suspensionDistance;
        }
        bool groundedR = wheel_right.GetGroundHit(out hit);
        if (groundedR)
        {
            travelR = (-wheel_right.transform.InverseTransformPoint(hit.point).y - wheel_right.radius) / wheel_right.suspensionDistance;
        }

        float anti_roll_force = (travelL - travelR) * anti_roll * -1;

        if(groundedL)
        {
            wheel_left.attachedRigidbody.AddForceAtPosition(wheel_left.transform.up * anti_roll_force, wheel_left.transform.position);
        }
        if (groundedR)
        {
            wheel_right.attachedRigidbody.AddForceAtPosition(wheel_right.transform.up * anti_roll_force, wheel_right.transform.position);
        }
    }
}
