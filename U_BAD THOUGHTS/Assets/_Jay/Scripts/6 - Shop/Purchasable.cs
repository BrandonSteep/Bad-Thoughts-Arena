using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchasable : Interactable
{
    public ItemClass item;
    [TextArea][SerializeField] private string inspectInfo;

    public int costPrice;

    public override void Interact()
    {
        if (References.inventoryManager.money.value >= costPrice)
        {
            References.inventoryManager.money.value -= costPrice;
            References.inventoryManager.Add(item);
            References.inspectController.ShowInfo(inspectInfo);
            Destroy(this.gameObject);
        }
        else
        {
            References.inspectController.ShowInfo("Not Enough Cash");
        }
    }
}
