using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MazeManager.mazeManager.resetMaze();
    }
}
