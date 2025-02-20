using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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


    protected void ToggleRideOn()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&& isRide)
        {
            vehicle.SetActive(true);
            playerSpeed = 8f;

            foreach (AnimationHandler handler in animationHandlers)
                if (handler != null)
                handler.RideOn();

            
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            foreach (AnimationHandler handler in animationHandlers)
                if (handler != null)
                    handler.RideOff();

            vehicle.SetActive(false);
            playerSpeed = 5f;
        }
    }

    protected override void Update()
    {
        base.Update();
        ToggleRideOn();
    }

}
