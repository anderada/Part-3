using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{

    public List<Room> rooms;
    public static bool[,] maze = new bool[7,7];
    public GameObject baseRoom;
    public GameObject spinnyRoom;
    public GameObject pulseRoom;
    public static MazeManager mazeManager;

    // Start is called before the first frame update
    void Start()
    {
        mazeManager = GetComponent<MazeManager>();
        resetMaze();
    }

    public void resetMaze() {
        PlayerMovement.player.transform.position = new Vector3(0,-4,0);
        foreach(Room room in rooms)
        {
            Destroy(room.gameObject);
        }
        rooms.Clear();
        StartCoroutine(GenerateMaze());
    }

    public static void addMaze(int x, int y)
    {
        maze[x,y] = true;
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
                GameObject selection;
                float dice = Random.Range(0, 3);
                if (dice < 1)
                    selection = baseRoom;
                else if(dice < 2)
                    selection = spinnyRoom;
                else
                    selection = pulseRoom;

                Room newRoom = Instantiate(selection, new Vector3(j - 3,i - 3,0), Quaternion.identity).GetComponent<Room>();
                rooms.Add(newRoom);
                if(newRoom != null) newRoom.init();
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}
