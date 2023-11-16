using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItems : MonoBehaviour
{
    private void Destroy(){
        Destroy(this.gameObject);
    }

    private void ThrowItem(){
        var item = Instantiate(References.equippedController.equippedItem.itemStats.itemModel, this.transform.position, Quaternion.identity);
        item.GetComponent<Rigidbody>().AddForce(References.player.transform.forward * 7.5f, ForceMode.Impulse);

        Destroy();
    }

    void OnEnable(){
        PlayerStatus.OnDeath += ThrowItem;
    }

    void OnDisable(){
        PlayerStatus.OnDeath -= ThrowItem;
    }
}
