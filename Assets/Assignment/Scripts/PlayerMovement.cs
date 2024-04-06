using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 direction;
    private float rotation = 0f;
    public float speed = 2f;
    public float rotationSpeed = 20f;
    SpriteRenderer sr;
    public static PlayerMovement player;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(0, Input.GetAxis("Vertical"));
        rotation = -Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        transform.Rotate(0, 0, rotation * rotationSpeed * Time.deltaTime);
    }

    public void SetCol(Color colour){
        sr.color = colour;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Room room = collision.GetComponentInParent<Room>();
        SetCol(room.playerColor);
    }
}
