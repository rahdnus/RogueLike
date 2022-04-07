using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    int _floorCount=0;
    int spawnYpos=0;
    const int c_floorHeight=20,c_stepWidth=30;
    [SerializeField]GameObject[] A_RoomPrefabs;
    [SerializeField]GameObject A_StairsPrefab;
    bool initspawn=true;
    List<GameObject> R_RoomsInScene=new List<GameObject>();
    
    void Start()
    {
        initspawn=true;
        GenerateFloor();
        initspawn=false;
        R_RoomsInScene[2].GetComponent<Room>().OnTrigger+=GenerateFloor;
    }
    public void GenerateFloor()
    {
        float spawnXpos=0f;
        float Yaw=_floorCount%2==0?0:180;
        Quaternion rotation = Quaternion.Euler(0, Yaw, 0);

        for(int i=0;i<3;i++)
        {
            int index=Random.Range(0,A_RoomPrefabs.Length);
            GameObject level=Instantiate(A_RoomPrefabs[index],new Vector3(0,spawnYpos,spawnXpos),rotation);
            R_RoomsInScene.Add(level);
            spawnXpos+=c_stepWidth;
        }
        
        float stairspawnX=_floorCount%2==0?spawnXpos:-30f;
        Vector3 stairspawnPos=new Vector3(0,spawnYpos,stairspawnX);

        GameObject stairs=Instantiate(A_StairsPrefab,stairspawnPos,rotation);
        R_RoomsInScene.Add(stairs);

        _floorCount+=1;
        spawnYpos+=c_floorHeight;

        int mainindex=_floorCount%2==0?6:4;
        
        if(!initspawn)
        {
            R_RoomsInScene[mainindex].GetComponent<Room>().OnTrigger+=DeleteFloor;
            R_RoomsInScene[mainindex].GetComponent<Room>().OnTrigger+=GenerateFloor;
        }
   
    }
    public void DeleteFloor()
    {
        for(int i=0;i<4;i++)
        {
            Destroy(R_RoomsInScene[i].gameObject);
        }
            R_RoomsInScene.RemoveAt(0);
            R_RoomsInScene.RemoveAt(0);
            R_RoomsInScene.RemoveAt(0);
            R_RoomsInScene.RemoveAt(0);


    }
}
