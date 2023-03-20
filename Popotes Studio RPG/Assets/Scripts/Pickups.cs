using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int num;
    public enum ObjectType
    {
        Empty,
        RedMushroom,
        PurpleMushroom,
        BrownMushroom,
        BlueFlowers,
        RedFlowers,
        Roots,
        LeafDew,
        Key,
        PinkEgg,
        BluePotion,
        GreenPotion,
        RedPotion,
        Bread,
        Cheese,
        Meat
    }
    public ObjectType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Blue Flowers
            if(type == ObjectType.BlueFlowers)
            {
                if(InventoryItems.blueFlowers == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.blueFlowers++;
                Destroy(gameObject);
            }
            // Red Mushrooms
            else if (type == ObjectType.RedMushroom)
            {
                if (InventoryItems.redMushrooms == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.redMushrooms++;
                Destroy(gameObject);
            }
        }
    }

    void DisplayIcons()
    {
        InventoryItems.newIcon = num;
        InventoryItems.iconUpdate = true;
    }
}
