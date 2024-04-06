using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class WithoutCoroutines : MonoBehaviour
{
    public GameObject missile;
    public float speed = 5;
    public float turningSpeedReduction = 0.75f;

    float time = 0;
    float runTime = 0;
    quaternion oldHeading;
    quaternion newHeading;

    bool turning = false;

    public void MakeTurn(float turn)
    {
        time = 0;
        runTime = 1;
        turning = true;

        oldHeading = missile.transform.rotation;
        newHeading = oldHeading * Quaternion.Euler(0, 0, turn);
    }

    public void MoveForwards(float length)
    {
        turning = false;

        time = 0;
        runTime = length;
    }
    
    void Update()
    {
        time += Time.deltaTime;
        if (time < runTime) {
            if (turning)
            {
                missile.transform.rotation = Quaternion.Lerp(oldHeading, newHeading, time);
                missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
            }
            else
            {
                missile.transform.Translate(transform.right * speed * Time.deltaTime);
            }
            }
        }
}
