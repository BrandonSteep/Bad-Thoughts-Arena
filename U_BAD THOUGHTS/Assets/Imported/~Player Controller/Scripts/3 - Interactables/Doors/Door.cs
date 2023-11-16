using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : Interactable
{
    public DoorType doorType;

    public string sceneToLoad;
    public string sceneToUnload;
    public Transform resultLocation;

    void Start()
    {
        resultLocation = transform.Find("ResultLocation");
        sceneToUnload = this.gameObject.scene.name;
    }

    public override void Interact()
    {
        if (doorType.isLocked)
        {
            Debug.Log("Door's Locked");
            References.inspectController.ShowInfo(doorType.inspectInfo);
            return;
        }
        else
        {
            // Play Transition Animation //
            LocalReferences.sceneCanvasAnim.SetTrigger("SceneTransition");

            // Switch Scenes //
            References.sceneController.LoadScene(resultLocation, sceneToLoad, sceneToUnload);
        }
    }

    //public abstract class Interact
    //{}
}
