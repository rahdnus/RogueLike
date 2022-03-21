using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
        public Moves moves;
    [SerializeField] protected float MovementSpeed;
    [SerializeField] public Brain brain;
    public Animator animator;
    [SerializeField]protected Collider[] colliders;

    public virtual void Start()
    {
        animator=GetComponent<Animator>();
        brain.Init(this);
    }

    public virtual void Update()
    {
        brain.Tick();
    }
    public abstract void Move(Vector3 axis);
    public abstract void Attack(int index);
    public abstract void Dodge();

    public abstract void TakeDamage();
}
