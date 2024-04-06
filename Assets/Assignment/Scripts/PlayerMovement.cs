using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 direction;      //direction player is moving
    private float rotation = 0f;    //amount player is rotatin
    public float speed = 2f;        //speed player moves
    public float rotationSpeed = 20f;   //speed player rotates
    SpriteRenderer sr;  
    public static PlayerMovement player;

    private void Start()
    {
        //initialize components
        player = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        //set player movement to zero
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //get player input
        direction = new Vector2(0, Input.GetAxis("Vertical"));
        rotation = -Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //rotate and move player
        transform.Translate(direction * speed * Time.deltaTime);
        transform.Rotate(0, 0, rotation * rotationSpeed * Time.deltaTime);
    }

    //sets the player color
    public void SetCol(Color colour){
        sr.color = colour;
    }

    //when entering a new room, change the player color to the room's color
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Room room = collision.GetComponentInParent<Room>();
        SetCol(room.playerColor);
    }
}
