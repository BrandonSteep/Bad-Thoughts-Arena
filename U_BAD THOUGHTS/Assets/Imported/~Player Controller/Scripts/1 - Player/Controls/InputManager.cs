using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField]
    PlayerController playerController;

    PlayerControls controls;
    PlayerControls.LocomotionInputActions locomotionInput;

    Vector2 horizontalInput;
    Vector2 mouseLookInput;

    float running = 0;
    float aiming = 0;

    private void Awake()
    {
        controls = new PlayerControls();
        locomotionInput = controls.LocomotionInput;

        // MOVEMENT INPUT //
        locomotionInput.Movement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        locomotionInput.Run.performed += ctx => running = ctx.ReadValue<float>();

        // MOUSE LOOK INPUT //
        locomotionInput.MouseX.performed += ctx => mouseLookInput.x = ctx.ReadValue<float>();
        locomotionInput.MouseY.performed += ctx => mouseLookInput.y = ctx.ReadValue<float>();

        // INTERACTION INPUT //
        locomotionInput.Interact.performed += _ => playerController.Interact();

        // AIMING & ACTION INPUT //
        locomotionInput.Aim.performed += ctx => aiming = ctx.ReadValue<float>();

        locomotionInput.Action.performed += _ => playerController.Action();

        // INVENTORY //
        locomotionInput.Inventory.performed += _ => playerController.Inventory();

        // SLOT SELECTION //
        locomotionInput.SelectSlot1.performed += _ => playerController.SelectSlot(1);
        locomotionInput.SelectSlot2.performed += _ => playerController.SelectSlot(2);
        locomotionInput.SelectSlot3.performed += _ => playerController.SelectSlot(3);
        locomotionInput.SelectSlot4.performed += _ => playerController.SelectSlot(4);
        locomotionInput.SelectSlot5.performed += _ => playerController.SelectSlot(5);
        locomotionInput.SelectSlot6.performed += _ => playerController.SelectSlot(6);
    }

    private void FixedUpdate()
    {
        playerController.ReceiveInput(horizontalInput, mouseLookInput, running, aiming);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
