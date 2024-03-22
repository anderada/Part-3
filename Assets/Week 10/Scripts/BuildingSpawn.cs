using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    public Transform object1;
    public Transform object2;
    public Transform object3;
    float growthSpeed = 0.5f;

    void Start()
    {
        StartCoroutine(SpawnBuilding());
    }

    IEnumerator SpawnBuilding() {
        object1.localScale = Vector3.zero;
        object2.localScale = Vector3.zero;
        object3.localScale = Vector3.zero;

        float growthClock = 0;

        while (object1.localScale.x < 0.99f)
        { 
            growthClock += Time.deltaTime;
            object1.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, growthClock / growthSpeed);
            yield return null;
        }

        growthClock = 0;
        while (object2.localScale.x < 0.99f)
        {
            growthClock += Time.deltaTime;
            object2.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, growthClock / growthSpeed);
            yield return null;
        }

        growthClock = 0;
        while (object3.localScale.x < 0.99f)
        {
            growthClock += Time.deltaTime;
            object3.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, growthClock / growthSpeed);
            yield return null;
        }

        object1.localScale = Vector3.one;
        object2.localScale = Vector3.one;
        object3.localScale = Vector3.one;
    }
}
