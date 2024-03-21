using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject dagger;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    Coroutine DashRoutine;

    protected override void Attack(){
        if(DashRoutine != null) {
            StopCoroutine(DashRoutine);
        }

        destination = (Vector2)transform.position;
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        DashRoutine = StartCoroutine(Dash());
    }

    public override ChestType CanOpen(){
        return ChestType.Thief;
    }

    IEnumerator Dash(){
        speed = 10;
        while ((destination - (Vector2)transform.position).magnitude > 0.1f){
            yield return null;
        }
        speed = 3;
        base.Attack();
        yield return new WaitForSeconds(0.5f);
        Instantiate(dagger, (Vector2)spawnPoint1.position, Quaternion.identity);
        Instantiate(dagger, (Vector2)spawnPoint2.position, Quaternion.identity);
    }

    public override string ToString(){
        return "John the Level 99 Cunning Thief\n(Thief)";
    }
}
