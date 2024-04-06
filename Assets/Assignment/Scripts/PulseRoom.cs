using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PulseRoom : Room
{
    public GameObject pulser;       //the pulsy bit
    private float pulseSpeed = 0.5f;    //the speed of the pulsy bit

    override public void init()
    {
        base.init();    //play spawn animation, mark the grid
        playerColor = Color.magenta;    //set player color
        StartCoroutine(pulse());    //start the pulsy bit
    }

    IEnumerator pulse()
    { 
        //set scale to zero
        float pulserScale = 0;
        //do this forever
        while (true)
        {
            //grow the pulsy bit
            while (pulserScale < 0.8f)
            {
                pulserScale += Time.deltaTime * pulseSpeed;
                pulser.transform.localScale = new Vector3(pulserScale, pulserScale, 1);
                yield return null;
            }
            //shrink the pulsy bit
            while (pulserScale > 0f)
            {
                pulserScale -= Time.deltaTime * pulseSpeed;
                pulser.transform.localScale = new Vector3(pulserScale, pulserScale, 1);
                yield return null;
            }
        }
    }
}
