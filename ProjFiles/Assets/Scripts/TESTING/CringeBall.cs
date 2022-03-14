using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CringeBall : MonoBehaviour
{
    GameObject player;
    Vector3 attackDirection;
    bool isAttacking=false;
    [SerializeField] LayerMask collisionMask;
      RaycastHit hit;
    float counter=0f;
    float cooldowntime=5f;
    void Start()
    {
      player=FindObjectOfType<Player>().gameObject;
    }
    void Update()
    {
      counter+=Time.deltaTime;
      if(counter>cooldowntime)
      {
        counter=0f;
        isAttacking=false;
      }
      if (!isAttacking)
      {
        attackDirection = (player.transform.position - transform.position).normalized;
        Physics.Raycast(transform.position, attackDirection, out hit, Mathf.Abs(Vector3.Distance(player.transform.position ,transform.position)), collisionMask);
        if(hit.collider)
        if (hit.collider.GetComponentInParent<Player>())
        {
          // GetComponent<Rigidbody>().AddForce(60 * attackDirection, ForceMode.Impulse);
          // Debug.Log("attacking");
          isAttacking = true;
        }

      }
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
      if(other.gameObject.GetComponentInParent<Player>() && isAttacking)
      {
        // Debug.Log("getrekt");
        player.GetComponentInParent<Rigidbody>().AddForce(attackDirection*5,ForceMode.Impulse); 
        isAttacking=false;
      }   
    }
}
