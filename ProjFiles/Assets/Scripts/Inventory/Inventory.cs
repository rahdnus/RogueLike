using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Inventory;
public class Inventory : MonoBehaviour
{  
    // public List<Item> items;
    public List<Item> inventoryItems;
    public System.Action<Item> onAdd;

    public GameObject Canvas;
    
    // public PickUpItem item1,item2,item3,item4;
    void Start()
    {
        inventoryItems=new List<Item>();
    //     item4=item1;
    //     AddItem(item1);
    //     AddItem(item2);
    //     AddItem(item3);
    //     RemoveItem(item4);
     }
     public void Update()
     {
        // if(Input.GetKeyDown(KeyCode.Mouse3))
        // {
        //      Debug.Log(items.Count);
        // }
        // if(Input.GetKeyDown(KeyCode.Mouse4))
        // {
        //     items[0].Spawn(new Vector3(0,0,0));
        // }
     }
    void AddItem(Item item)
    {
        inventoryItems.Add(item);
        onAdd(item);
    }
    public void RemoveItem(Item item)
    {
        inventoryItems.Remove(item);
    }
    void OnTriggerEnter(Collider other)
    {
        if(1<<other.gameObject.layer !=LayerMask.GetMask("Item"))
            return;
        PickUpItem pickupitem=other.gameObject.GetComponentInParent<PickUpItem>();
        AddItem(pickupitem.item);
        pickupitem.PickedUp();
    }
  
}
