using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{

    public List<Room> rooms;    //list of rooms
    public static bool[,] maze = new bool[7,7]; //map of which spots on the grid have rooms in them
    public GameObject baseRoom;     //prefab for the base room
    public GameObject spinnyRoom;   //prefab for the room with the spinner in it
    public GameObject pulseRoom;    //prefab for the room with the pulser in it
    public static MazeManager mazeManager;  //static reference to this object

    // Start is called before the first frame update
    void Start()
    {
        //set static reference to this object
        mazeManager = GetComponent<MazeManager>();
        //generate the maze
        resetMaze();
    }

    public void resetMaze() {
        //reset player position
        PlayerMovement.player.transform.position = new Vector3(0,-4,0);
        //delete the previous maze
        foreach(Room room in rooms)
        {
            Destroy(room.gameObject);
        }
        rooms.Clear();
        //generate a new maze
        StartCoroutine(GenerateMaze());
    }

    //marks a spot on the grid as having a room in it
    public static void addMaze(int x, int y)
    {
        maze[x,y] = true;
    }

    IEnumerator GenerateMaze() { 
        //initialize the room list
        rooms = new List<Room>();
        //mark the grid as all false
        for(int i = 0; i < 7; i++) {
            for (int j = 0; j < 7; j++) {
                maze[i, j] = false;
            }
        }

        //itterate through the grid spaces
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                //select a random room
                GameObject selection;
                float dice = Random.Range(0, 3);
                if (dice < 1)
                    selection = baseRoom;
                else if(dice < 2)
                    selection = spinnyRoom;
                else
                    selection = pulseRoom;

                //instantiate the room
                Room newRoom = Instantiate(selection, new Vector3(j - 3,i - 3,0), Quaternion.identity).GetComponent<Room>();
                //add it to the rooms list
                rooms.Add(newRoom);
                //initialize the room
                if(newRoom != null) newRoom.init();
                //wait for a bit before the next room
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}
