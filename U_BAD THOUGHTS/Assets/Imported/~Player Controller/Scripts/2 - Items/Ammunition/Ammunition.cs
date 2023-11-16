using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Class", menuName = "Item/Ammunition")]
public class Ammunition : ItemClass
{
    [Header("Ammunition Stats")]
    // Stats Specific to Ammunition //
    public int ammoCount;

    public enum AmmunitionType
    {
        handgunAmmo,
        shotgunAmmo,
        flameFuel
    }

    public override ItemClass GetItem() { return this; }
    public override Weapon GetWeapon() { return null; }
    public override Consumable GetConsumable() { return null; }
    public override Key GetKey() { return null; }
    public override Ammunition GetAmmunition() { return this; }
}
