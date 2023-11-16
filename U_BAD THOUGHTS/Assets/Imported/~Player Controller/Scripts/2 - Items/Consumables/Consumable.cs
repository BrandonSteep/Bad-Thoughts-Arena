using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Class", menuName = "Item/Consumable")]
public class Consumable : ItemClass
{
    [Header("Consumable Stats")]
    // Stats Specific to Consumables //
    public int healAmount;

    public override ItemClass GetItem() { return this; }
    public override Weapon GetWeapon() { return null; }
    public override Consumable GetConsumable() { return this; }
    public override Key GetKey() { return null; }
    public override Ammunition GetAmmunition() { return null; }
}
