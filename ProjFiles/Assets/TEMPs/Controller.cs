using UnityEngine;
using Hanabi;
namespace Core
{
namespace Actor{
public class Controller : MonoBehaviour,IDamagable
{
    [SerializeField]AudioClip[] damageClips;
    Rigidbody2D rb;
    [SerializeField] float[] jumpHeight;
    [SerializeField] Transform groundcheck;
    float horizontal;
    int j_count=0;
    float j_timer=0,j_holdtime=0.25f;
    // Brak brak;
    bool jump=false,grounded=false;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(j_timer!=0)
        Debug.Log(j_timer);
        horizontal= Input.GetAxis("Horizontal");

        if(!jump)
        {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundcheck.position, 0.2f, LayerMask.GetMask("Ground"));
		for (int i = 0; i < colliders.Length; i++)
		{
    			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
				j_count=0;
                j_timer=0;
			}
        }
        }
       

        if(Input.GetKeyDown(KeyCode.Space)&&(grounded||j_count<2))
        {
            j_count++;
            jump=true;
            grounded=false;
            j_timer=0;
            // Debug.Log(j_count);
        }

        else if(Input.GetKeyUp(KeyCode.Space))
        {
            j_timer=0;
            jump=false;
        }
        if(jump)
        {
            j_timer+=Time.deltaTime;
            if(j_timer>j_holdtime)
            {
                jump=false;
                j_timer=0;
            }
        }

       
    }
    void FixedUpdate()
    {
        rb.velocity= new Vector3(horizontal* 10f,rb.velocity.y,0);
       
        // if(jump && (grounded||j_count<2))
        // {
        //     grounded=false;
        //     rb.AddForce(new Vector2(0,jumpHeight[j_count]));
        //     j_count++;
        // }
        if(jump)
        {
            rb.AddForce(new Vector2(0,jumpHeight[j_count-1]));
        }
        // brak.Move(horizontal,false,jump);

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
