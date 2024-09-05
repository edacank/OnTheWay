using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Araba : MonoBehaviour
{
    public WheelCollider SolOnTekerlek, SolArkaTekerlek, SagOnTekerlek, SagArkaTekerlek;
    public float motorhizi;
    public float donmehizi;

    // Update is called once per frame
    void Update()
    {
        SolArkaTekerlek.motorTorque = motorhizi * Input.GetAxis("Vertical");
        SagArkaTekerlek.motorTorque = motorhizi * Input.GetAxis("Vertical");
        SagOnTekerlek.steerAngle = donmehizi * Input.GetAxis("Horizontal");
        SolOnTekerlek.steerAngle = donmehizi * Input.GetAxis("Horizontal");
    }
}
