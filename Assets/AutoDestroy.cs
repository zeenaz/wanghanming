using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public bool DestoryParent = false;
    public float DestoryDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DestroyMe()
    {
        if (DestoryParent)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void DestroyMeWithDelay()
    {
        Invoke("DestroyMe", DestoryDelay);
    }
}
