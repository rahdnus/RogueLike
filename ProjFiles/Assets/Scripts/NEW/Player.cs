using UnityEngine;
using Hanabi;
namespace Core
{
namespace Actor{
public class Player : MonoBehaviour,IDamagable
{
    [SerializeField]AudioClip[] damageClips;
    Rigidbody2D rb;
    [SerializeField] float[] jumpHeight;
    public Transform groundcheck;
   [HideInInspector] public float horizontal;
    // Brak brak;
    public bool jump=false,grounded=false;
    public int j_count=0;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }   
    void FixedUpdate()
    {
        rb.velocity= new Vector3(horizontal* 10f,rb.velocity.y,0);

        if(jump)
        {
            rb.AddForce(new Vector2(0,jumpHeight[j_count-1]));
        }

    }
    public void TakeDamage()
    {
        rb.velocity=Vector2.zero;
        // rb.AddForce(direction*200);
        int index=Random.Range(0,damageClips.Length);
        AudioSource.PlayClipAtPoint(damageClips[index],transform.position);
        GetComponent<Animator>().SetTrigger("Damaged");
    }
   
}

}}