using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI villagerDisplay;
    public Villager[] villagers;


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
        /*
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        */
    }

    public void SetSelectedVillagerDropdown(TMP_Dropdown menu)
    {
        int index = menu.value;
        if (villagers.Length >= index)
        {
            if (SelectedVillager != null)
            {
                SelectedVillager.Selected(false);
            }

            SelectedVillager = villagers[index];
            SelectedVillager.Selected(true);
        }
    }
    
}
