using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SellButton : MonoBehaviour
{
    private Button _button;

    public UnityAction<int,int> ActivateAntiBuyButton;

    public int bodyPart;
    public int partId;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => { Sell(); });
    }
    
    public void Sell()
    {
        if(BodyPartsManager.instance.Sell(bodyPart, partId)) // if the process is ok. it checks if it is last item or wearing it.
        {
            ActivateAntiBuyButton(bodyPart,partId);
            _button.gameObject.SetActive(false);
        }
    }
}
