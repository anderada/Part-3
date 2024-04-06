using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyRoom : Room
{
    public GameObject spinner;      //the spinny bit
    private float spinSpeed = 100f; //the speed of the spinny bit

    override public void init() { 
        base.init();    //play spawn animation, mark grid
        playerColor = Color.cyan;   //set player color
    }

    private void FixedUpdate()
    {
        spin();
    }

    private void spin() {
        //spin the spinny bit
        spinner.transform.Rotate(new Vector3(0,0,spinSpeed * Time.deltaTime));
    }
}
