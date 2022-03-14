using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="EncounterTable",menuName="SO/Table/Encounter")]
public class EncounterTable : ScriptableObject
{
public Encounter[] encounters;
    
}
[System.Serializable]
public class Encounter
{
    public GameObject[] enemies;
}
