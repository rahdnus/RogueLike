using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Room : MonoBehaviour
{
    public event Action OnTrigger;
    [SerializeField]Spawner spawner;
    [SerializeField]GameObject trigger;

    void Start()
    {
        OnTrigger+=spawner.SpawnEnemies;
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponentInParent<Player>())
        {
            Debug.Log(gameObject.name+other.gameObject.name);

            Destroy(trigger);
            if(OnTrigger!=null)
                 OnTrigger();
        }
    }
}
