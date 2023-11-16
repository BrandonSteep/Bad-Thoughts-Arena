using UnityEngine;
using TMPro;


public class SignController : MonoBehaviour
{
    [SerializeField] private Purchasable purchasable;
    [SerializeField] private TMP_Text textBox;

    void Start()
    {
        textBox.text = purchasable.item.itemName + "\n" + "£ " + purchasable.costPrice.ToString();
    }

}
