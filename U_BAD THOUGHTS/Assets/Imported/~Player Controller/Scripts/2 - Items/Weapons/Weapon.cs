using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Class", menuName = "Item/Weapon")]
public class Weapon : ItemClass
{
    [Header("Weapon Stats")]
    // Stats Specific to Weapons //
    public int weaponDamage;

    public enum WeaponType
    {
        blunt,
        sharp,
        firearm,
        fire
    }

    public override ItemClass GetItem() { return this; }
    public override Weapon GetWeapon(){ return this; }
    public override Consumable GetConsumable() { return null; }
    public override Key GetKey() { return null; }
    public override Ammunition GetAmmunition() { return null; }
}
