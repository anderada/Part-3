using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDemo : MonoBehaviour
{
    float total = 0;

    public void lerpColor(float value){
        total += value;
        GetComponent<SpriteRenderer>().color = new Color(1, Mathf.Lerp(1, 0, total/60f), Mathf.Lerp(1, 0, total/60f));
    }

    public void SetSprite(Image toSet){
        GetComponent<SpriteRenderer>().sprite = toSet.sprite;

    }
}
