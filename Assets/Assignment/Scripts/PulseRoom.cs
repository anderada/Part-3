using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PulseRoom : Room
{
    public GameObject pulser;
    private float pulseSpeed = 0.5f;

    override public void init()
    {
        base.init();
        playerColor = Color.magenta;
        StartCoroutine(pulse());
    }

    IEnumerator pulse()
    {
        float pulserScale = 0;
        while (true)
        {
            while (pulserScale < 0.8f)
            {
                pulserScale += Time.deltaTime * pulseSpeed;
                pulser.transform.localScale = new Vector3(pulserScale, pulserScale, 1);
                yield return null;
            }
            while (pulserScale > 0f)
            {
                pulserScale -= Time.deltaTime * pulseSpeed;
                pulser.transform.localScale = new Vector3(pulserScale, pulserScale, 1);
                yield return null;
            }
        }
    }
}
