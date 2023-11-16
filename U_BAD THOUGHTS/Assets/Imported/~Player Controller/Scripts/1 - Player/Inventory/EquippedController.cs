using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedController : MonoBehaviour
{
    public ItemAnimationManager equippedItem;

    public void Action()
    {
        if (equippedItem != null)
        {
            equippedItem.Action();
        }
    }
}
