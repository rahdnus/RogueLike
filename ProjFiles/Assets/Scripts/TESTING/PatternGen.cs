using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternGen : MonoBehaviour
{
    int num=0;
  [SerializeField]GameObject[] prefab;
  List<GameObject> leftbounds=new List<GameObject>();
  List<GameObject> rightbounds=new List<GameObject>();
  List<GameObject> upbounds=new List<GameObject>();
  List<GameObject> downbounds=new List<GameObject>();

  List<GameObject> Levels=new List<GameObject>();
  public GameObject sartRoom;
void Start()
{
    for(int i=0;i<prefab.Length;i++)
    {
        var bound=prefab[i].GetComponent<Bounds>();
          if(bound.left!=null)
        {
            leftbounds.Add(prefab[i]);
        }
          if(bound.right!=null)
        {
            rightbounds.Add(prefab[i]);
        }
          if(bound.up!=null)
        {
            upbounds.Add(prefab[i]);
        }
          if(bound.down!=null)
        {
            downbounds.Add(prefab[i]);
        }
    }
    Bounds startbound=sartRoom.GetComponent<Bounds>();
    int nextindex=Encode(startbound);
            Debug.Log(nextindex);

    Summon(nextindex);
    // for(int i=0;i<num;i++)
    // {
    //     Levels[i].transform.position+=new Vector3(1,1,1)*i;
    // }
}
int Encode(Bounds bound)
{
        int nextindex = 0;
        if (bound.left != null)
        {
            nextindex =nextindex*10 + 1;
        }
        if (bound.right != null)
        {
            nextindex =nextindex*10+ 2;
        }
        if (bound.up != null)
        {
            nextindex =nextindex*10 + 3;
        }
        if (bound.down != null)
        {
            nextindex =nextindex*10 + 4;
        }
        return nextindex;
}
 void Summon(int i)
    {
        if (i == 0)
            return;
        if (num > 10)
            return;
        while (i % 10 != 0)
        {
            int index = i % 10;
            int randomnumber;
            GameObject inst = null;
            switch (index)
            {
                case 1:
                    randomnumber = Random.Range(0, leftbounds.Count);
                    inst = (Instantiate(leftbounds[randomnumber], Vector3.zero, Quaternion.identity));
                    Levels.Add(inst);
                    break;
                case 2:
                    randomnumber = Random.Range(0, rightbounds.Count);
                    inst = (Instantiate(rightbounds[randomnumber], Vector3.zero, Quaternion.identity));
                    Levels.Add(inst);
                    break;
                case 3:
                    randomnumber = Random.Range(0, upbounds.Count);
                    inst = (Instantiate(upbounds[randomnumber], Vector3.zero, Quaternion.identity));
                    Levels.Add(inst);
                    break;
                case 4:
                    randomnumber = Random.Range(0, downbounds.Count);
                    inst = (Instantiate(downbounds[randomnumber], Vector3.zero, Quaternion.identity));
                    Levels.Add(inst);
                    break;

            }
            if (inst != null)
            {
                int nextindex = 0;
                var bound = inst.GetComponent<Bounds>();
                
                nextindex=Encode(bound);
                Summon(nextindex);
            }
            i /= 10;
            num++;
        }
 }
}
