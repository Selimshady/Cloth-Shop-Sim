using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public BuyButton[] buyButtons;
    public SellButton[] sellButtons;

    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        foreach (BuyButton button in buyButtons)
        {
            button.ActivateAntiSellButton += onActivateAntiSellButton;
        }
        foreach (SellButton button in sellButtons)
        {
            button.ActivateAntiBuyButton += onActivateAntiBuyButton;
        }
    }

    private void OnEnable()
    {
        moneyText.text = BodyPartsManager.inventory.money.ToString() + "$";
        foreach(BuyButton button in buyButtons)
        {
            if (BodyPartsManager.inventory.GetObject(button.bodyPart, button.partId))
                button.gameObject.SetActive(false);
            else
                button.gameObject.SetActive(true);
        }
        foreach (SellButton button in sellButtons)
        {
            if (BodyPartsManager.inventory.GetObject(button.bodyPart, button.partId))
                button.gameObject.SetActive(true);
            else
                button.gameObject.SetActive(false);
        }
    }

    public void onActivateAntiBuyButton(int bodyPart, int partId)
    {
        moneyText.text = BodyPartsManager.inventory.money.ToString() + "$";
        buyButtons[bodyPart * 2 + partId].gameObject.SetActive(true);
    }

    public void onActivateAntiSellButton(int bodyPart, int partId)
    {
        moneyText.text = BodyPartsManager.inventory.money.ToString() + "$";
        sellButtons[bodyPart * 2 + partId].gameObject.SetActive(true);
    }
}
