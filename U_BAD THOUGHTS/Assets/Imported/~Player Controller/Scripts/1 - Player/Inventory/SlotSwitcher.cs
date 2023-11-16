using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSwitcher : MonoBehaviour
{
    public int selectedSlot = 0;
    
    private Image spriteImage;

    public bool canSwap = true;

    private void Start()
    {
        UpdateSlots(selectedSlot);
    }

    public void SelectSlot(int newSlot)
    {
        if (newSlot != selectedSlot + 1 && canSwap)
        {
            int oldSlot = selectedSlot;
            selectedSlot = newSlot - 1;
            UpdateSlots(oldSlot);
            //Debug.Log(selectedSlot);
        }
    }

    void UpdateSlots(int oldSlot)
    {
        int i = 0;
        foreach (Transform slot in transform)
        {
            spriteImage = slot.GetComponent<Image>();

            if (i == selectedSlot)
            {
                spriteImage.color = new Color(1, 1, 1, 0.2f);
            }
            else
            {
                spriteImage.color = new Color(1, 1, 1, 0);
            }
            i++;
        }
        if (selectedSlot != oldSlot)
        {
            canSwap = false;
            References.inventoryManager.SelectSlot(selectedSlot);
        }
    }
}
