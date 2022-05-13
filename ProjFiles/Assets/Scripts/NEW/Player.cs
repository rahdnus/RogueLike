using UnityEngine;
using TMPro;
using Hanabi;
using DokkaebiBag.Generic;

namespace Core.Actor{
public class Player : MonoBehaviour,IDamagable,IPick
{
    public Inventory inventory;
    [SerializeField]GameObject damagePrefab,canvas;
    [SerializeField]int Health=100;
    [SerializeField]AudioClip[] damageClips;
    Rigidbody2D rb;
    [SerializeField] float[] jumpHeight;
    public Transform groundcheck;
   [HideInInspector] public float horizontal;
    public bool jump=false,grounded=false;
    public int j_count=0;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inventory.Click();
        inventory.RightClick();
    }

    void FixedUpdate()
    {
        rb.velocity= new Vector3(horizontal* 10f,rb.velocity.y,0);

        if(jump)
        {
            rb.AddForce(new Vector2(0,jumpHeight[j_count-1]));
        }
    }
    public void PickUp(Item.Data data)
    {
        inventory.AddToInventory(data);
    }
    public void TakeDamage(int damage)
    {
        Health-=damage;
        rb.velocity=Vector2.zero;
        var damagefx=Instantiate(damagePrefab,transform.position,Quaternion.identity);
        damagefx.transform.SetParent(canvas.transform);
        damagefx.GetComponentInChildren<TextMeshProUGUI>().text=damage.ToString();
        Destroy(damagefx,2f);
        int index=Random.Range(0,damageClips.Length);
        AudioSource.PlayClipAtPoint(damageClips[index],transform.position);
        GetComponent<Animator>().SetTrigger("Damaged");
    }
   
}

}
