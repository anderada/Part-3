using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderClock : MonoBehaviour
{
    public Slider toIncrement;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(incrementEachSecond());
    }

    IEnumerator incrementEachSecond(){
        while(true){
            toIncrement.value += 1;
            yield return new WaitForSeconds(1);
        }
    }
}
