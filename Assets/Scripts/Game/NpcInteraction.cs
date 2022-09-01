using UnityEngine;
using UnityEngine.Events;

public class NpcInteraction : MonoBehaviour
{
    public bool isInRange;
    public UnityAction TriggerExit;

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
            TriggerExit();
        }    
    }

}
