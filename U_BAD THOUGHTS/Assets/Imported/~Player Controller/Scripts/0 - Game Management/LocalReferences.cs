using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalReferences : MonoBehaviour
{
    public static LocalReferences instance;

    public static Transform sceneCanvas;
    public static Animator sceneCanvasAnim;

    void OnEnable()
    {
        instance = this;

        sceneCanvas = transform.Find("SceneCanvas");
        sceneCanvasAnim = sceneCanvas.GetComponent<Animator>();
    }
}
