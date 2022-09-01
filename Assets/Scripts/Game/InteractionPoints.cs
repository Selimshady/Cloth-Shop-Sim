using UnityEngine;
using TMPro;
using System.Collections;

public class InteractionPoints : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float textSpeed;
    public string[] sentences;
    int no;

    private bool _isInRange;
    private int _index = 0;
    public GameObject panel;


    private void Update()
    {
        if(_isInRange && Input.GetKeyDown(KeyCode.E) && !panel.activeInHierarchy)
        {
            panel.SetActive(true);
            text.text = string.Empty;

            _index = 0;
            no = Random.Range(0,sentences.Length);
            StartCoroutine(SayIt(no));
        }
    }
    
    IEnumerator SayIt(int no)
    {
        foreach(char c in sentences[no].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(1);
        panel.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            _isInRange = false;
        }
    }

}
