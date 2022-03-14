using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    [SerializeField] GameObject A_pointerSFX;

    public override void Start()
    {
        // base.Start();

       var sfx= Instantiate(A_pointerSFX,transform.position,Quaternion.identity);
        Destroy(sfx,3f);
    }
    public override void Update()
    {

    }
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Dodge()
    {
        throw new System.NotImplementedException();
    }

    public override void Move(Vector3 axis)
    {
        throw new System.NotImplementedException();
    }
}
