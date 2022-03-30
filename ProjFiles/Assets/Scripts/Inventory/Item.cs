using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Inventory{
[System.Serializable]
public abstract class Item 
{
    int id;
    public GameObject itemPrefab;
    public Item()
    {
       itemPrefab=Resources.Load("Prefabs/TestItem") as GameObject;
    }
    public void Spawn(Vector3 position)
    {
        GameObject.Instantiate(itemPrefab,position,Quaternion.identity);
    }
}
public class TestItem:Item
{
    public TestItem():base()
    {
     }
}
}