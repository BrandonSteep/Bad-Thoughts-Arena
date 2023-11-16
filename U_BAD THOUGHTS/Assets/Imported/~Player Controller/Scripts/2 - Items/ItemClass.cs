using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    [Header("Item Stats")]
    // Data Shared Across All Items //
    public int itemID;
    public string itemName;
    [TextArea] public string itemDescription;

    public bool isStackable = false;
    public int quantity = 1;

    public GameObject equippableItem;
    public Sprite itemSprite;
    public GameObject itemModel;

    public abstract ItemClass GetItem();
    public abstract Weapon GetWeapon();
    public abstract Consumable GetConsumable();
    public abstract Key GetKey();
    public abstract Ammunition GetAmmunition();

}
