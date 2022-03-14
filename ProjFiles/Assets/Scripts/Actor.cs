using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField] protected float MovementSpeed;
    [SerializeField] protected Brain brain;
    public Animator animator;
    [SerializeField]protected Collider[] colliders;

    public virtual void Start()
    {
        animator=GetComponent<Animator>();
        // GetComponent<Rigidbody>().AddForce(Vector3.forward*-1500,ForceMode.Force);
        brain.Init(this);
    }

    public virtual void Update()
    {
        brain.Tick();
    }
    public abstract void Move(Vector3 axis);
    public abstract void Attack();
    public abstract void Dodge();
}
