using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvonteryController : MonoBehaviour
{
    public DressButton[] dressButtons;

    public static InvonteryController instance;
    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        foreach (var button in dressButtons)
        {
            if(BodyPartsManager.inventory.GetObject(button.bodyPart,button.partId))
                button.gameObject.SetActive(true);
            else
                button.gameObject.SetActive(false);
        }
    }
}
