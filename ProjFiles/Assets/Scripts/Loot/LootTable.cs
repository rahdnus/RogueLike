using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="SO/LootTable",fileName="LootTable")]
public class LootTable:ScriptableObject
{
    [SerializeField]Loot[] loot;
    int minDropAmount=2,maxDropAmount=6;
    int total=0;
    GameObject dropparent;
    public void Init()
    {
            total=0;

        foreach(Loot _loot in loot)
        {
            total+=_loot.dropWeight;
        }
    }
    public void SpawnLoot(Vector3 SpawnPosition)
    {   
        dropparent=new GameObject("DROPS");
        
        int i=0;
        int drops=Random.Range(minDropAmount,maxDropAmount);
        for(int j=0;j<drops;j++)
        {
            int num = Random.Range(0, total);
            Debug.Log(num);
            while (total - loot[i].dropWeight > num && i > -1)
            {
                total = total - loot[i].dropWeight;
                i++;
            }
            loot[i].Spawn(SpawnPosition,dropparent.transform);
        }
       
       
    }
}
[System.Serializable]
public class Loot{
    [SerializeField]GameObject item;
    public int dropWeight=10;
    public void Spawn(Vector3 position,Transform parenttransform)
    {
        
        Debug.Log(item.gameObject.name);
        GameObject.Instantiate(item,position,Quaternion.identity).transform.SetParent(parenttransform);
    }
}

