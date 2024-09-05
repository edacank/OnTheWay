using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Araba_1 : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

         [SerializeField] private float motorForce;
         [SerializeField] private float breakForce;
         [SerializeField] private float maxSteerAngle;
 
         [SerializeField] private WheelCollider SagOnCollider;
         [SerializeField] private WheelCollider SolArkaCollider;
         [SerializeField] private WheelCollider SolOnCollider;
         [SerializeField] private WheelCollider SagArkaCollider;

         [SerializeField] private Transform SagArkaTekerlek; 
         [SerializeField] private Transform SolOnTekerlek;
         [SerializeField] private Transform SolArkaTekerlek;
         [SerializeField] private Transform SagOnTekerlek;





     private void FixedUpdate()
     {
         GetInput();
         HandleMotor();
         HandleSteering();
         UpdateWheels();

          // frontLeftWheelCollider.motorTorque = 0.17f * motorForce;
    }

     private void GetInput()
    {
         horizontalInput = Input.GetAxis(HORIZONTAL);
         verticalInput = Input.GetAxis(VERTICAL);
         isBreaking = Input.GetKey(KeyCode.Space);
    }

     private void HandleMotor()
    {
         SolOnCollider.motorTorque = verticalInput * motorForce;
         SagOnCollider.motorTorque = verticalInput * motorForce;
         currentbreakForce = isBreaking ? breakForce : 0f;
         ApplyBreaking();
    }

     private void ApplyBreaking()
    {
         SagOnCollider.brakeTorque = currentbreakForce;
         SolOnCollider.brakeTorque = currentbreakForce;
         SolArkaCollider.brakeTorque = currentbreakForce;
         SagArkaCollider.brakeTorque = currentbreakForce;
    }

     private void HandleSteering()
    {
         currentSteerAngle = maxSteerAngle * horizontalInput;
         SolOnCollider.steerAngle = currentSteerAngle;
         SagOnCollider.steerAngle = currentSteerAngle;
    } 

     private void UpdateWheels()
    {
         UpdateSingleWheel(SolOnCollider, SolOnTekerlek);
         UpdateSingleWheel(SagOnCollider, SagOnTekerlek);
         UpdateSingleWheel(SagArkaCollider, SagArkaTekerlek);    
         UpdateSingleWheel(SolArkaCollider, SolArkaTekerlek);
    }

     private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
         Vector3 pos;
         Quaternion rot;
         wheelCollider.GetWorldPose(out pos, out rot);
         wheelTransform.rotation = rot;
         wheelTransform.position = pos;
    }
    
}
