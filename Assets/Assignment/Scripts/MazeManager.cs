using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{

    public List<Room> rooms;
    public static bool[,] maze = new bool[7,7];
    public GameObject baseRoom;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateMaze());
    }


    IEnumerator GenerateMaze() { 
        rooms = new List<Room>();
        for(int i = 0; i < 7; i++) {
            for (int j = 0; j < 7; j++) {
                maze[i, j] = false;
            }
        }

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Room newRoom = Instantiate(baseRoom, new Vector3(j - 3,i - 3,0), Quaternion.identity).GetComponent<Room>();
                rooms.Add(newRoom);
                if(newRoom != null) newRoom.init();
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}
