using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    // INPUT //
    private Vector2 mouseLookInput;
    private Vector3 initialPosition;



    // Parameters //
    public float amount;
    public float maxAmount;
    public float smoothAmount;



    // References




    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void FixedUpdate()
    {
        mouseLookInput = References.playerController.mouseLookInput * amount;

        //Clamp the Sway//
        mouseLookInput.x = Mathf.Clamp(mouseLookInput.x, -maxAmount, maxAmount);
        mouseLookInput.y = Mathf.Clamp(mouseLookInput.y, -maxAmount, maxAmount);

        //Move the Object//
        Vector3 finalPosition = new Vector3(mouseLookInput.x, mouseLookInput.y, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount);
    }
}
