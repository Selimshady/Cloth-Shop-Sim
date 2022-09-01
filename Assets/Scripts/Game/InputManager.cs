using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject inventoryMenu;
    public NpcInteraction npc;

    private void Awake()
    {
        npc.TriggerExit = ShopTriggerExit;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !shopMenu.activeInHierarchy) // block if shop menu is active
        {
            if (inventoryMenu.activeInHierarchy)
                inventoryMenu.SetActive(false);
            else
                inventoryMenu.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.F) && !inventoryMenu.activeInHierarchy) // block if inventory is active
        {
            if(npc.isInRange)
            {
                if (shopMenu.activeInHierarchy)
                    shopMenu.SetActive(false);
                else
                    shopMenu.SetActive(true);
            }
        }
    }

    public void ShopTriggerExit() 
    {
        shopMenu.SetActive(false); // if get away from npc
    }
}
