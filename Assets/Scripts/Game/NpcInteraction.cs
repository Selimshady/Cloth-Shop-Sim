using UnityEngine;
using UnityEngine.Events;

public class NpcInteraction : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public GameObject canvas;

    void Update()
    {
        if(isInRange && !InvonteryController.instance.gameObject.activeInHierarchy)
        {
            if(Input.GetKeyDown(interactKey))
            {
                if(canvas.activeInHierarchy)
                    canvas.SetActive(false);
                else
                    canvas.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                canvas.SetActive(false);
            }
        }
    }
 
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.GetComponent<PlayerMovement>())
        {
            isInRange = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>())
        {
            isInRange = false;
        }    
    }

}
