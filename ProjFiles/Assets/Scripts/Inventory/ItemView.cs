using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Inventory;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    public Item item;
    System.Action<ItemView> onUsed;
    public void Init(Item _item,InventoryView view)
    {
        this.item=_item;
        gameObject.GetComponentInChildren<Image>().sprite= Resources.Load<Sprite>("Prefabs/Items/"+item.itemSpriteName);    
        gameObject.GetComponentInChildren<Button>().onClick.AddListener(onClick); 
        onUsed+=view.RemoveUI;
    }
    void onClick()
    {
        item.Use();
        onUsed(this);
        Destroy(gameObject,0.2f);
    }
}
