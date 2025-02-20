using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : BaseController
{
    private GameObject currentHat;
    private GameObject currentClothes;

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

    }

    protected override void SetIsLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            isLeft = true;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            isLeft = false;
    }

    
}
