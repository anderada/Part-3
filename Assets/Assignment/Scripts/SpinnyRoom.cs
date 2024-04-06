using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyRoom : Room
{
    public GameObject spinner;
    private float spinSpeed = 100f;

    override public void init() { 
        base.init();
        playerColor = Color.cyan;
    }

    private void FixedUpdate()
    {
        spin();
    }

    private void spin() {
        spinner.transform.Rotate(new Vector3(0,0,spinSpeed * Time.deltaTime));
    }
}
