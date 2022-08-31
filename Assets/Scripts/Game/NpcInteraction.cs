using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class NpcInteraction : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject canvas;

    public Button[] buttons;
    public TMP_Text moneyText;

    private bool shopMenuActive;

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
                UpdateUI();
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                CloseShopMenu();
            }
        }
    }
    public void CloseShopMenu()
    {
        canvas.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<PlayerMovement>())
        {
            Debug.Log("inRange");
            isInRange = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlayerMovement>())
        {
            Debug.Log("outRange");
            isInRange = false;
        }    
    }

    public void OpenSelectionMenu()
    { 
        canvas.SetActive(true);
    }

    public void UpdateUI()
    {
        /*int money = Invontery.instance.getMoney();
        moneyText.SetText(money.ToString());
        if(money < 10)
        {
            for(int i=0;i<buttons.Length;i++)
            {
                buttons[i].interactable = false;
            }
        }
        else
        {
            for(int i=0;i<buttons.Length;i++)
            {
                buttons[i].interactable = true;
            }
        }
        */
    }
}
