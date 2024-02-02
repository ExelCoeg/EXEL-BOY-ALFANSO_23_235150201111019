
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;



public class RandomWeaponDrops : MonoBehaviour
{
    public GameObject droppedWeaponPrefab;
    public List<Weapon> weapons = new List<Weapon>();
   
    Weapon GetRandomWeapon()
    {
        int randomNum = Random.Range(1, 101);
        foreach (Weapon weapon in weapons)
        {
            if (randomNum <= weapon.dropChance)
            {
                return weapon;
            }
           
        }
        print("No weapon dropped");
        return null;
    }

    public void InstantiateWeapon(Vector3 dropPosition)
    {
        Weapon droppedWeapon = GetRandomWeapon();
        if(droppedWeapon != null)
        {
            GameObject weaponGameObject = Instantiate(droppedWeaponPrefab, dropPosition, Quaternion.identity);
            weaponGameObject.GetComponent<SpriteRenderer>().sprite = droppedWeapon.weaponSprite;

            float dropForce = 2f;
            Vector2 dropDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            weaponGameObject.GetComponent<Rigidbody2D>().AddForce(dropDir * dropForce, ForceMode2D.Impulse);

            if(droppedWeapon.weaponName == "Shotgun")
            {
                weaponGameObject.tag = "Shotgun";
            }
        }
    }

}

