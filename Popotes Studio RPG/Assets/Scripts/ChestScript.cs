using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private Animator animator;
    public int goldAmount = 50;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InventoryItems.key) {
                animator.SetTrigger("open");
                InventoryItems.gold += goldAmount;
                goldAmount = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InventoryItems.key)
            {
                animator.SetTrigger("close");
            }
        }
    }

    public void DestroyChest()
    {
        Destroy(gameObject);
    }
}
