using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Old._Inventory;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemView : MonoBehaviour
{
    public Item item;
    System.Action<ItemView> onViewSelect,onUsed;

    public void Init(Item _item,InventoryView view)
    {
        this.item=_item;
        gameObject.GetComponentInChildren<Image>().sprite= Resources.Load<Sprite>("Prefabs/Items/"+item.itemSpriteName);    
        gameObject.GetComponentInChildren<Button>().onClick.AddListener(onClick); 
        onViewSelect+=view.setContext;
        onUsed+=view.RemoveUI;
    }
    //     public void OnPointerClick(PointerEventData pointerEventData)
    // {
    //     //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
    //     Debug.Log(name + " Game Object Clicked!");
    // }
    public void Use()
    {
        item.Use();
        Destroy(gameObject,0.2f);
        onUsed(this);
    }
    public void Drop(Vector3 position)
    {
       item.Spawn(position);
       Destroy(gameObject,0.2f);
       onUsed(this);
    }
    void onClick()
    {
        onViewSelect(this);
    }
}
