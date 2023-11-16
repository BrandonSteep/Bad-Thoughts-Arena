using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // VARIABLES //
    #region Variables
    // INPUT //
    [Header ("Input")]
    [SerializeField]
    CharacterController controller = null;
    Vector2 horizontalInput;
    public Vector2 mouseLookInput;
    public float running;
    public float aiming;



    // M I S C   M O V E M E N T //
    [Header ("Movement")]
    // MOVEMENT VARIABLES //
    [SerializeField] [Tooltip("Default: Default 2.75")] float walkSpeed = 2.75f;    
    [SerializeField] [Tooltip("Default: Default 0.75")] float aimWalkSpeedMultiplier = 0.75f;
    [SerializeField] float currentWalkSpeed;

    // R U N N I N G //
    [SerializeField] float runSpeedMultiplier = 2.0f;
    [SerializeField] bool canRun = true;
    [SerializeField] [Tooltip("Default: 100")] ScriptableVariable currentStamina;
    [SerializeField] [Tooltip("Default: 100")] ScriptableVariable maxStamina;
    [SerializeField] [Tooltip("Default: 15")] float staminaDrainRate = 20f;
    [SerializeField] [Tooltip("Default: 20")] float staminaRefillRate = 20f;

    // S L O P E S //
    [SerializeField] private float slopeForce;
    [SerializeField] private float slopeForceRayLength;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    // M O U S E   L O O K //
    [Header ("Mouse Look")]
    [SerializeField] Transform playerCamera = null;
    public float mouseSensitivity = 3.5f;
    [SerializeField] private ScriptableVariable mouseSensitivitySO;
    //[SerializeField] float aimSpeed = 2.0f;

    [SerializeField] bool lockCursor = true;

    float cameraPitch = 0.0f;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    //// INTERACTION //
    //[SerializeField]
    //private float interactDistance = 200f;
    //private Interactable interactable;

    // INVENTORY //
    [Header("Inventory")]
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private ItemSlotSwitcher slotsContainer;
    [SerializeField] private SlotSwitcher slots;


    // GRAVITY //
    [Header("Physics")]
    float velocityY = 0.0f;
    [SerializeField] float gravity = -13.0f;

    // SMOOTHING //
    [Header ("Smoothing")]
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.15f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;



    //// LOCATION TRACKER //
    //[SerializeField] string currentLocation;

    //// ENEMY VARIABLES //
    //public bool isGrabbed = false;
    #endregion



    // FRAME-BASED ///
    #region Frame-Based Methods
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = References.cam.transform;
        
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        currentWalkSpeed = walkSpeed;

        inventory = GameObject.FindGameObjectWithTag("Inventory");
        slotsContainer = inventory.GetComponentInChildren<ItemSlotSwitcher>();

        currentStamina.value = maxStamina.value;

    }

    void Awake(){
        LoadSettings();
    }

    void LoadSettings(){
        PlayerData myData = SaveSystem.LoadData();
        if(myData != null){
            mouseSensitivity = myData.sensitivity;
        }
        else{
            // SaveSystem.SaveData();
        }
    }

    void FixedUpdate()
    {
        UpdateGravity();
        UpdateMouseLook();
        UpdateMovement();
        // UpdateStamina();

        //Debug.Log("stamina = " + stamina);
    }
    #endregion



    // MOVEMENT //
    #region Keyboard & Mouse Controls

    void UpdateMovement()
    {
        Vector2 targetDir = horizontalInput;
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (aiming == 1f)
        {
            currentWalkSpeed *= aimWalkSpeedMultiplier;
        }

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * currentWalkSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

        if (horizontalInput != new Vector2(0, 0))
        {
            // Animation & Running //
            UpdateRunning();

            if (OnSlope())
            {
                controller.Move(Vector3.down * controller.height / 2 * slopeForce * Time.deltaTime);
            }
        }
        else
        {
            References.playerAnim.SetInteger("Walking", 0);
        }

    }

    // MOUSE LOOK //
    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = mouseLookInput;

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -85.0f, 85.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);

    }
    #endregion



    // RUNNING //
    #region Running

    void UpdateRunning()
    {
        if (running == 1 && canRun)
        {
            References.playerAnim.SetInteger("Walking", 2);
            currentWalkSpeed = walkSpeed * runSpeedMultiplier;
            // currentStamina.value -= Time.deltaTime * staminaDrainRate;
            // if (currentStamina.value <= 0)
            // {
            //     canRun = false;
            // }
            // else if (currentStamina.value == maxStamina.value)
            // {
            //     canRun = true;
            // }
        }
        else
        {
            References.playerAnim.SetInteger("Walking", 1);
            currentWalkSpeed = walkSpeed;
        }
    }

    // void UpdateStamina()
    // {
    //     if (running != 1 || horizontalInput == new Vector2(0, 0) || !canRun)
    //     {
    //         if (currentStamina.value < maxStamina.value)
    //         {
    //             currentStamina.value += Time.deltaTime * staminaRefillRate;
    //         }
    //         else
    //         {
    //             canRun = true;
    //         }
    //     }
    // }
    #endregion


        
    // INVENTORY //
    #region Inventory

    public void Inventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
    }

    public void SelectSlot(int slot)
    {
        //slotsContainer.SelectSlot(slot);
        slots.SelectSlot(slot);
    }
    #endregion



    // ENVIRONMENTAL INTERACTION //
    #region Environmental Interaction
    // INTERACT //
    public void Interact()
    {
        Debug.Log(References.selection);
        References.selection.Interact();
    }

    // ACTION //
    public void Action()
    {
        References.equippedController.Action();
    }

    //// TRIGGER HANDLING //

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        Debug.Log("In Range");
    //        ZombieAI zombieAI = other.GetComponentInParent<ZombieAI>();

    //        if (other.name == "Bite Range")
    //        {
    //            Debug.Log("Grabbed by" + other.name);
    //            isGrabbed = true;
    //            zombieAI.StartBite();
    //        }
    //        else if (other.name == "Awareness Range")
    //        {
    //            Debug.Log("Player Seen");
    //            zombieAI.playerSeen = true;
    //        }
    //        else
    //        {
    //            zombieAI.InRange();
    //        }
    //    }
    //}
    #endregion



    // PHYSICS //
    #region Physics 
    // GRAVITY //
    void UpdateGravity()
    {
        if (controller.isGrounded)
        {
            velocityY = 0.0f;
        }

        velocityY += gravity * Time.deltaTime;
    }

    // SLOPE CHECK //
    private bool OnSlope()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, controller.height / 2 * slopeForceRayLength))
        {
            if (hit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
    #endregion



    // INPUT //
    #region Input

    public void ReceiveInput(Vector2 _horizontalInput, Vector2 _mouseLookInput, float _running, float _aiming)
    {
        if(controller.enabled == true){
        horizontalInput = _horizontalInput;
        mouseLookInput = _mouseLookInput;
        running = _running;
        aiming = _aiming;
        }
        else{
            horizontalInput = new Vector2 (0f, 0f);
            mouseLookInput = new Vector2 (0f, 0f);
            running = 0f;
            aiming  = 0f;
        }
    }

    public void ControllerEnabled()
    {
        controller.enabled = true;
    } 
    
    public void ControllerDisabled()
    {
        References.playerAnim.SetTrigger("OnDeath");
        controller.enabled = false;
    }
    #endregion



    void OnEnable(){
        PlayerStatus.OnDeath += ControllerDisabled;
    }

    void OnDisable(){
        PlayerStatus.OnDeath -= ControllerDisabled;
    }
}
