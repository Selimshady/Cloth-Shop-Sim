using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject invonteryMenu;
    public NpcInteraction npc;

    private void Awake()
    {
        npc.TriggerExit = InventoryTriggerExit;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !shopMenu.activeInHierarchy)
        {
            if (invonteryMenu.activeInHierarchy)
                invonteryMenu.SetActive(false);
            else
                invonteryMenu.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.F) && !invonteryMenu.activeInHierarchy)
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

    public void InventoryTriggerExit()
    {
        shopMenu.SetActive(false);
    }
}
