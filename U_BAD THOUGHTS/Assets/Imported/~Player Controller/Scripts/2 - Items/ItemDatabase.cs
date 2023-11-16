using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System / Database / Item Database")]
public class ItemDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemClass[] items;
    public Dictionary<int, ItemClass> GetItem = new Dictionary<int, ItemClass>();

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].itemID = i;
            GetItem.Add(i, items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemClass>();
    }
}