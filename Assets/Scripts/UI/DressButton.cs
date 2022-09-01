using UnityEngine;
using UnityEngine.UI;

public class DressButton : MonoBehaviour
{
    private Button _button;

    public int bodyPart;
    public int partId;


    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => { Dress(); });
    }

    public void Dress()
    {
        BodyPartsManager.instance.Dress(bodyPart, partId); // no need to control if it is changed
    }
}
