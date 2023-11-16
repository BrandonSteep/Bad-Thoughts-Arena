using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : Interactable
{
    [SerializeField] private int amount;
    [SerializeField] private string moneyType;

    public override void Interact()
    {
        References.inventoryManager.money.value += amount;

        References.inspectController.ShowInfo(moneyType);
        Destroy(this.gameObject);
    }
}
