using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    float growSpeed = 5f;
    public Color playerColor = Color.white;

    public virtual void init()
    {
        StartCoroutine(Spawn());
        MazeManager.addMaze((int)(transform.position.x) + 3, (int)(transform.position.y) + 3);
    }
    public IEnumerator Spawn() {
        Vector3 scale = new Vector3(0,0,1);
        transform.localScale = scale;
        while (scale.x < 1)
        {
            scale.x += Time.deltaTime * growSpeed;
            scale.y += Time.deltaTime * growSpeed;
            transform.localScale = scale;
            yield return null;
        }
        scale.x = 1;
        scale.y = 1;
        transform.localScale = scale; 
    }
}
