using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    float growSpeed = 5f;   //speed that the spawn animation plays at
    public Color playerColor = Color.white; //player color on entering the room

    public virtual void init()
    {
        //play the spawn animation
        StartCoroutine(Spawn());
        //mark the grid as having a room at this location
        MazeManager.addMaze((int)(transform.position.x) + 3, (int)(transform.position.y) + 3);
    }
    public IEnumerator Spawn() {
        //set scale to zero
        Vector3 scale = new Vector3(0,0,1);
        transform.localScale = scale;

        while (scale.x < 1)
        {
            //grow room each frame
            scale.x += Time.deltaTime * growSpeed;
            scale.y += Time.deltaTime * growSpeed;
            transform.localScale = scale;
            yield return null;
        }

        //set scale to 1
        scale.x = 1;
        scale.y = 1;
        transform.localScale = scale; 
    }
}
