using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Inventory;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    Item item;
    public void Init(Item _item)
    {
        this.item=_item;
        Debug.Log("Prefabs/Items/"+item.itemSpriteName);
        Debug.Log(gameObject.GetComponentInChildren<Image>());
        gameObject.GetComponentInChildren<Image>().sprite= Resources.Load<Sprite>("Prefabs/Items/"+item.itemSpriteName);     
    }
    void onClick()
    {
        item.Use();
    }
}
