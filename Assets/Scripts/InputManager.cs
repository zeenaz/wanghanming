using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent onShoot = new UnityEvent();
    public UnityEvent onReload = new UnityEvent();
    public UnityEvent onDie = new UnityEvent();
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            onShoot.Invoke();
        }
        

        if (Input.GetKeyDown(KeyCode.R))
        {
            onReload.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
            //open menu
        }
        
        //Press P to kill player
        if (Input.GetKeyDown(KeyCode.P))
        {
            onDie.Invoke();
        }
    }
}