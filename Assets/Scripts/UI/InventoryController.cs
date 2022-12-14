using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public DressButton[] dressButtons;

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
