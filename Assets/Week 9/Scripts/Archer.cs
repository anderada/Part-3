using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Villager
{

    public GameObject arrow;
    public Transform spawnPoint;

    protected override void Attack(){
        base.Attack();
        destination = (Vector2)transform.position;
        Instantiate(arrow, spawnPoint);
    }

}