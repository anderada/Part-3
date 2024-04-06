using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    float speed = 5f;
    public Color playerColor = Color.green;

    public void init()
    {
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn() {
        Vector3 scale = new Vector3(0,0,1);
        transform.localScale = scale;
        while (scale.x < 1)
        {
            scale.x += Time.deltaTime * speed;
            scale.y += Time.deltaTime * speed;
            transform.localScale = scale;
            yield return null;
        }
        scale.x = 1;
        scale.y = 1;
        transform.localScale = scale; 
    }
}
