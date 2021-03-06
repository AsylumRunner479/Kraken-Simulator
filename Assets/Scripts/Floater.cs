﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floaterCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    public bool water;
    public Vector3 originalPos;
    private void Awake()
    {
        originalPos = new Vector3(transform.position.x + Random.Range(-1,1), transform.position.y, transform.position.z + Random.Range(-1, 1));
    }
    private void FixedUpdate()
    {
        rigidBody.AddForceAtPosition(Physics.gravity/ floaterCount, transform.position, ForceMode.Acceleration);
        float waveHeight = (WaveManager.instance.GetWaveHeight(transform.position.x) + WaveManager.instance.GetWaveHeight2(transform.position.z))/2;
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight-transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            rigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rigidBody.AddForce(displacementMultiplier * -rigidBody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidBody.AddTorque(displacementMultiplier * -rigidBody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            if (water == true)
            {
                if (transform.position.x < originalPos.x)
                {
                    rigidBody.AddForceAtPosition(new Vector3(Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f, 0f), transform.position, ForceMode.Acceleration);
                }
                if (transform.position.x > originalPos.x)
                {
                    rigidBody.AddForceAtPosition(new Vector3(-Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f, 0f), transform.position, ForceMode.Acceleration);
                }
                if (transform.position.z < originalPos.z)
                {
                    rigidBody.AddForceAtPosition(new Vector3(0f, 0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier), transform.position, ForceMode.Acceleration);
                }
                if (transform.position.z > originalPos.z)
                {
                    rigidBody.AddForceAtPosition(new Vector3(0f, 0f, -Mathf.Abs(Physics.gravity.y) * displacementMultiplier), transform.position, ForceMode.Acceleration);
                }
            }
        }
        
    }
}
