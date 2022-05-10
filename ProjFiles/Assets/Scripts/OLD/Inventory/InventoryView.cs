using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Old._Inventory{

public class InventoryView : MonoBehaviour
{
    [SerializeField]Inventory inventory;
    [SerializeField]Transform UiContainer;
    List<ItemView> UI_items=new List<ItemView>();
    // bool inventoryinFocus;
    ItemView currentView;

    [SerializeField]GameObject UI_template;

    void Start()
    {
        inventory.onAdd+=AddUI;
        // inventoryinFocus=true;

    }
    void Update()
    {
        if(currentView==null) 
            return;
        
        if(!Input.anyKeyDown)
            return;

        if(Input.GetKeyDown(KeyCode.Q))
        {
            currentView.Use();
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            currentView.Drop(inventory.transform.position);
        }

    }
    void AddUI(Item item)
    {
        GameObject UI=Instantiate(UI_template,Vector3.zero,Quaternion.identity);
        UI.transform.SetParent(UiContainer);
        ItemView view=UI.AddComponent<ItemView>();
        view.Init(item,this);
        UI_items.Add(view);
    }
      public void setContext(ItemView view)
    {
        if(currentView==view)
        {
            currentView=null;

        }
        else
        {
        currentView=view;
        }
    }
    public void RemoveUI(ItemView view)
    {
        currentView=null;
        UI_items.Remove(view);
        inventory.RemoveItem(view.item);
    }
}
}