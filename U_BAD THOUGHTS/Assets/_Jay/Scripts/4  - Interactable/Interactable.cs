using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] public Sprite interactableSprite;

    public virtual void Interact()
    { }
}
