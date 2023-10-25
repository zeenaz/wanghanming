using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject ObjectToActivate;
    public GameObject ObjectToDeactivate;
    public bool ToActivate;
    public bool ToDeactivate;
    public bool IsOneTimeTrigger;
    
    private bool isTriggered = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            if (ToActivate)
            {
                ObjectToActivate.SetActive(true);
            }
            if (ToDeactivate)
            {
                ObjectToDeactivate.SetActive(false);
            }
            if (IsOneTimeTrigger)
            {
                isTriggered = true;
            }
        }
    }
}
