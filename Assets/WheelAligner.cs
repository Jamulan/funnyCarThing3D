using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAligner : MonoBehaviour
{
    public WheelCollider wheel;

    float rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rotation += wheel.rpm * (Time.deltaTime * 10.0f);
        
        transform.localRotation = Quaternion.Euler(new Vector3(rotation, wheel.steerAngle, 0.0f));
    }
}
