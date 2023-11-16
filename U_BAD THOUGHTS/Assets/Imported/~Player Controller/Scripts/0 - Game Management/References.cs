using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class References : MonoBehaviour
{
    public static References instance { get; private set; }

    public static GameObject gameManager;

    public static ObjectPool objectPool;

    // Player //
    public static GameObject player;
    public static CharacterController characterController;
    public static PlayerController playerController;
    public static PlayerStatus playerStatus;
    public static Camera cam;
    public static PlayerKnockback playerKnockback;
    public static Animator playerAnim;

    // Inventory //
    public static SlotSwitcher slotSwitcher;
    public static EquippedController equippedController;

    // Scene Management //
    public static SceneController sceneController;
    public static SelectionManager selection;

    // Interaction //
    public static InspectController inspectController;

    public static InventoryManager inventoryManager;



    void Awake()
    {
        instance = this;

        gameManager = this.gameObject;
        objectPool = GetComponentInChildren<ObjectPool>();

        player = gameManager.transform.Find("Player").gameObject;
        characterController = player.GetComponent<CharacterController>();
        playerController = player.GetComponent<PlayerController>();
        playerStatus = player.GetComponent<PlayerStatus>();
        cam = Camera.main;
        playerKnockback = player.GetComponent<PlayerKnockback>();
        playerAnim = player.GetComponent<Animator>();

        slotSwitcher = GameObject.FindWithTag("SlotHolder").GetComponent<SlotSwitcher>();
        equippedController = player.GetComponent<EquippedController>();

        sceneController = GetComponent<SceneController>();
        selection = GetComponent<SelectionManager>();

        inspectController = GetComponent<InspectController>();

        inventoryManager = GameObject.FindWithTag("Inventory").GetComponent<InventoryManager>();
    }



    // PAUSE //

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }



    // RESUME //

    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
