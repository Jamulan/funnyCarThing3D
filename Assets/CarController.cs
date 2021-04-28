using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float engine_power;
    public float steering_power;

    public WheelCollider front_right;
    public WheelCollider front_left;
    public WheelCollider back_right;
    public WheelCollider back_left;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float engine = Input.GetAxisRaw("Vertical") * engine_power * Time.deltaTime;

        front_left.motorTorque = engine;
        front_right.motorTorque = engine;
        back_left.motorTorque = engine;
        back_right.motorTorque = engine;

        float steering = Input.GetAxisRaw("Horizontal") * steering_power;

        front_left.steerAngle = steering;
        front_right.steerAngle = steering;
    }
}
