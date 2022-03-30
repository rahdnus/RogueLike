using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Inventory{
public  class PickUpItem : MonoBehaviour
{
    int id;
    public Item item;
    public void Start()
    {
        item=new TestItem();
    }
    public void PickedUp()
    {
        Destroy(gameObject);
    }
}}