using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public InteractionPoints[] interactionPoints;
    public GameObject panel;
    public TextMeshProUGUI text;
    public float textSpeed;

    private string _activeText;

    private void Awake()
    {
        for (int i = 0; i < interactionPoints.Length; i++)
            interactionPoints[i].SayIt = onSayIt;
    }

    public void onSayIt(string sentence)
    {
        if(!panel.activeInHierarchy)
        {
            panel.SetActive(true);
            text.text = string.Empty;
            _activeText = sentence;
            StartCoroutine(Type());
        }
    }
    IEnumerator Type()
    {
        foreach (char c in _activeText.ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(0.75f);
        panel.SetActive(false);
    }
}
