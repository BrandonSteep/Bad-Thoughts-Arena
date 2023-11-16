using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Class", menuName = "Item/Key")]
public class Key : ItemClass
{
    //[Header("Key Stats")]
    // Stats Specific to Keys //




    public enum KeyType
    {
        doorKey,
        keyItem,
        singleUse
    }



    public override ItemClass GetItem() { return this; }
    public override Weapon GetWeapon() { return null; }
    public override Consumable GetConsumable() { return null; }
    public override Key GetKey() { return this; }
    public override Ammunition GetAmmunition() { return null; }
}