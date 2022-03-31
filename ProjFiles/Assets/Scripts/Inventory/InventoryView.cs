using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Inventory;

public class InventoryView : MonoBehaviour
{
    [SerializeField]Inventory inventory;
    [SerializeField]Transform UiContainer;
    List<ItemView> UI_items=new List<ItemView>();
    [SerializeField]GameObject UI_template;

    void Start()
    {
        inventory.onAdd+=AddUI;
    }

    void AddUI(Item item)
    {
        GameObject UI=Instantiate(UI_template,Vector3.zero,Quaternion.identity);
        UI.transform.SetParent(UiContainer);
        ItemView view=UI.AddComponent<ItemView>();
        view.Init(item);
        UI_items.Add(view);
    }
    void RemoveUI()
    {

    }
}
