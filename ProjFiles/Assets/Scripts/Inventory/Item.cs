using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Inventory{
[System.Serializable]
public abstract class Item 
{
    int id;
    public string itemSpriteName;
    public GameObject itemPrefab;
    public Item()
    {
       itemPrefab=Resources.Load("Prefabs/TestItem") as GameObject;
    }
    public abstract void Use();
    public void Spawn(Vector3 position)
    {
        GameObject.Instantiate(itemPrefab,position,Quaternion.identity);
    }
}
public class TestItem:Item
{
    public TestItem():base()
    {
        itemSpriteName="1";
     }

        public override void Use()
        {
            Debug.Log("Used");
        }
    }
}