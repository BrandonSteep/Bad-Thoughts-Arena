using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;

    public bool inventoryFull;

    [SerializeField] SlotClass[] startingItems;
    private GameObject[] slots;
    public SlotClass[] items;

    private Image spriteImage;

    [SerializeField] private int selectedSlot;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemDescription;

    [SerializeField] private GameObject equippedSlot;

    [SerializeField] private SlotSwapTimer slotSwapTimer;

    public ScriptableVariable money;

    public void Awake()
    {
        // Create Slot Array and Assign Slot Numbers //
        slots = new GameObject[slotHolder.transform.childCount];
        items = new SlotClass[slots.Length];

        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new SlotClass();
        }
        for (int i = 0; i < startingItems.Length; i++)
        {
            items[i] = startingItems[i];
        }


        // Set the Slots //
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }

        // Test Inventory Functions //
        if (itemToAdd != null) Add(itemToAdd);
        if (itemToRemove != null) Remove(itemToRemove);

        selectedSlot = 0;
        RefreshUI();

        money.value = 0;
    }

    #region Add & Remove
    // Add an Item to the Inventory //
    public bool Add(ItemClass item)
    {
        // Check if Inventory Contains an Item //
        SlotClass slot = Contains(item);
        if (slot != null && slot.GetItem() != null && slot.GetItem().isStackable)
        {
            //slot.AddQuantity(1);
        }
        else
        {
            int slotToPick = References.slotSwitcher.selectedSlot;
            if (items[slotToPick].GetItem() == null)
            {
                items[slotToPick].AddItem(item, item.quantity);
            }
            else
            {
                Debug.Log("Inventory slot " + slotToPick + " is full");
            }
            //for (int i = 0; i < items.Length; i++)
            //{
            //if (items[i].GetItem() == null) // This Slot is Empty //
            //{
            //    items[i].AddItem(item, item.quantity);

            //    break;
            //}
            //}

            //if (items.Count < slots.Length)
            //{
            //    items.Add(new SlotClass(item, 1));
            //}
            //else
            //{
            //    return false;
            //}
        }

        // Refresh the UI //
        RefreshUI();
        return true;
    }


    public void AddMoney(int amount)
    {
        money.value += amount;
    }


    // Remove an Item From the Inventory //
    public bool Remove(ItemClass item)
    {
        //items.Remove(item);
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
            {
                temp.RemoveQuantity(1);
            }
            else
            {
                int slotToRemoveIndex = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].GetItem() == item)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }

                //// Remove the Item //
                items[slotToRemoveIndex].Clear();
            }
        }
        else
        {
            return false;
        }

        // Refresh the UI //
        RefreshUI();
        return true;
    }
    #endregion

    // Check Whether a Certain Item is Already in the Inventory //
    public SlotClass Contains(ItemClass item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetItem() == item)
            {
                return items[i];
            }
        }
        return null;
    }


    public void SelectSlot(int slot)
    {
        selectedSlot = slot;
        RefreshUI();

        StartCoroutine(slotSwapTimer.SlotTimer());

        //Debug.Log(selectedSlot);
    }


    // Refresh the Inventory UI //
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            spriteImage = slots[i].transform.GetChild(0).GetComponent<Image>();

            for (int x = 0; x < items.Length; x++)
            {
                if (items[x].GetItem() == null) // This Slot is Empty //
                {
                    spriteImage.color = new Color(1, 1, 1, 0);
                    slots[i].transform.GetChild(1).GetComponent<TMP_Text>().text = "";
                    spriteImage.enabled = false;

                    break;
                }
            }


            if (items[i].GetItem() != null)
            {
                spriteImage.enabled = true;
                spriteImage.sprite = items[i].GetItem().itemSprite;
                spriteImage.color = new Color(1, 1, 1, 1);
                if (items[i].GetItem().isStackable)
                {
                    slots[i].transform.GetChild(1).GetComponent<TMP_Text>().text = items[i].GetQuantity().ToString();
                }
                else
                {
                    slots[i].transform.GetChild(1).GetComponent<TMP_Text>().text = "";
                }
            }
        }

        if (items[selectedSlot].GetItem() != null)
        {
            itemName.text = items[selectedSlot].GetItem().name;
            itemDescription.text = items[selectedSlot].GetItem().itemDescription;
        }
        else
        {
            itemName.text = "";
            itemDescription.text = "";
        }
        SwapEquipment();
    }


    private void SwapEquipment()
    {
        if (equippedSlot.transform.childCount != 0)
        {
            //Remove Existing Item//
            Destroy(equippedSlot.transform.GetChild(0).gameObject);
        }
        if (items[selectedSlot].GetItem() != null)
        {
            //Instantiate New Item//
            Instantiate(items[selectedSlot].GetItem().equippableItem, equippedSlot.transform);
            StartCoroutine(RefreshItem());
        }
    }

    IEnumerator RefreshItem()
    {
        yield return new WaitForSeconds(0.05f);
        //Debug.Log(equippedSlot.transform.GetChild(0).name);
        References.equippedController.equippedItem = equippedSlot.transform.GetChild(0).GetComponent<ItemAnimationManager>();

        //Set Layer As Equipped//
        SetLayerRecursively(equippedSlot.transform.GetChild(0).gameObject);

        yield return null;
    }

    public static void SetLayerRecursively(GameObject obj)
    {
        obj.layer = 8;

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            SetLayerRecursively(obj.transform.GetChild(i).gameObject);
        }
    }
}
