using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent onShoot = new UnityEvent();
    public UnityEvent onReload = new UnityEvent();
    public UnityEvent onDead = new UnityEvent();
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            onShoot.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            onReload.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.P))
        {
            onDead.Invoke();

        }
        
    }
}