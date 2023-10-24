using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_Player : CharacterControllerBase
{ 
    // Player-specific properties and methods go here
    
    protected override void Update()
    {
        base.Update();
        HandleInput();
    }

    private void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
}
