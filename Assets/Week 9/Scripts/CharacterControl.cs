using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI villagerDisplay;

    void Start(){
        villagerDisplay.text = "None Selected";
    }

    void FixedUpdate(){
        if(SelectedVillager != null){
            villagerDisplay.text = SelectedVillager.ToString();
        }
        else {
            villagerDisplay.text = "None Selected";
        }
    }

    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
    }
    
}
