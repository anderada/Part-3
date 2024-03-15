using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject dagger;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    protected override void Attack(){
        base.Attack();
        destination = (Vector2)transform.position;
        Instantiate(dagger, (Vector2)spawnPoint1.position, Quaternion.identity);
        Instantiate(dagger, (Vector2)spawnPoint2.position, Quaternion.identity);
        speed = 10;
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public override ChestType CanOpen(){
        return ChestType.Thief;
    }
}
