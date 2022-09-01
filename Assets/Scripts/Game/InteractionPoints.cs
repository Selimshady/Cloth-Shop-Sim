using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Events;

public class InteractionPoints : MonoBehaviour
{
    public string[] sentences;
    public UnityAction<string> SayIt;

    private bool _isInRange;

    private void Update()
    {
        if (_isInRange && Input.GetKeyDown(KeyCode.E))
        {
            SayIt(sentences[Random.Range(0, sentences.Length)]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isInRange = false;
    }

}
