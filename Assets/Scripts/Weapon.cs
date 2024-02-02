using System;
using UnityEngine;
[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public Sprite weaponSprite;
    public string weaponName;
    public int dropChance;

    public Weapon(string weaponName, int dropChance)
    {
       
        this.weaponName = weaponName;
        this.dropChance = dropChance;
    }
}