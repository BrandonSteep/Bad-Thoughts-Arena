using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotSwitcher : MonoBehaviour
{
    [SerializeField] private int selectedSlot = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectSlot(selectedSlot);
    }

    public void SelectSlot(int newSlot)
    {
        if (newSlot != selectedSlot + 1)
        {
            selectedSlot = newSlot - 1;
            UpdateSlots();
            //Debug.Log(selectedSlot);
            References.equippedController.equippedItem = GetComponentInChildren<ItemAnimationManager>();
        }
    }

    void UpdateSlots()
    {
        int i = 0;
        foreach (Transform slot in transform)
        {
            if (i == selectedSlot)
            {
                slot.gameObject.SetActive(true);
            }
            else
            {
                slot.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
