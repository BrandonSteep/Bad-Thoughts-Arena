using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    public ItemClass item;
    [TextArea] [SerializeField] private string inspectInfo;

    public override void Interact()
    {
        References.inventoryManager.Add(item);
        References.inspectController.ShowInfo(inspectInfo);
        Destroy(this.gameObject);
    }
}
