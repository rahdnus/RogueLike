using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]Transform[] R_SpawnPoints;
    [SerializeField]EncounterTable A_EncounterTable;
 public void SpawnEnemies()
 {
    int recordIndex=Random.Range(0,A_EncounterTable.encounters.Length);
    Encounter encounter=A_EncounterTable.encounters[recordIndex];

    int maxenemies=R_SpawnPoints.Length;
    for(int i=0;i<encounter.enemies.Length;i++)
    {
            int index=Random.Range(0,maxenemies);
         
            Instantiate(encounter.enemies[i],R_SpawnPoints[index].position,Quaternion.identity);
    }
 }
}
