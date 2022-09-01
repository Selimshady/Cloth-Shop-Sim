using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    private Button _button;

    public UnityAction<int,int> ActivateAntiSellButton;
    
    public int bodyPart;
    public int partId;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => { Buy(); });
    }

    public void Buy()
    {
        if(BodyPartsManager.instance.Buy(bodyPart, partId)) // if the process is ok checks for money
        {
            ActivateAntiSellButton(bodyPart,partId);
            _button.gameObject.SetActive(false);
        }
    }
}
