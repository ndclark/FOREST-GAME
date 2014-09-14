using UnityEngine;
using System.Collections;

public class Boar_AI : MonoBehaviour
{
	public GameObject player = null;
	public float attackDistance;
	public float speed;
	public float minDirectionChangeTime, senseDistance;
	public float damageDone, deltaAttackTime;
	private float boarWidth, boarHeight;
	private bool isMovingX = false, firstAttack = true;
	private float t;
	private short health = 2;
	Animator anim;
	
	
	void Awake()
	{
		t = -minDirectionChangeTime;
		anim = GetComponent <Animator>();
		if(player == null)
			player = GameObject.FindGameObjectWithTag("Player");
	}
	
	public void takeDamage()
	{
		gameObject.GetComponent<DamageEffect>().Init();
		--health;
		if(health <= 0)
			die ();
	}
	
	void die()
	{
		//TODO Spawn meat
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 neededMov = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
		float curDistance = neededMov.magnitude;
		t += Time.deltaTime;
		
		if(neededMov.magnitude < senseDistance)
		{
			if(curDistance <= attackDistance)
			{
				if(firstAttack == true)
				{
					t=1000f;
					firstAttack = false;
				}
				
				if(t>deltaAttackTime)
				{
					t = 0f;
					Camera.main.GetComponent<HudScript>().Player_Health-=damageDone;
					player.GetComponent<DamageEffect>().Init ();
				}
			}
			else
			{
				if(t > minDirectionChangeTime)
				{
					t = 0f;
					isMovingX = Mathf.Abs(neededMov.x) > Mathf.Abs(neededMov.y);
				}
				
				if(isMovingX)
				{
					gameObject.GetComponent<BoxCollider2D>().size = new Vector2(2.3f,1.55f);
					//move along X
					if(neededMov.x < 0)
					{
						transform.Translate(-speed * Time.deltaTime, 0f, 0f);
						anim.SetBool("WalkL",true);
						anim.SetBool("WalkR",false);
						anim.SetBool("WalkF",false);
						anim.SetBool("WalkB",false);
					}
					else
					{
						transform.Translate(speed * Time.deltaTime, 0f, 0f);
						anim.SetBool("WalkL",false);
						anim.SetBool("WalkR",true);
						anim.SetBool("WalkF",false);
						anim.SetBool("WalkB",false);
					}
				}
				else
				{
					gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.22f,1.65f);
					//Move along Y
					if(neededMov.y < 0)
					{
						transform.Translate(0f, -speed * Time.deltaTime, 0f);
						anim.SetBool("WalkL",false);
						anim.SetBool("WalkR",false);
						anim.SetBool("WalkF",true);
						anim.SetBool("WalkB",false);
					}
					else
					{
						transform.Translate(0f, speed * Time.deltaTime, 0f);
						anim.SetBool("WalkL",false);
						anim.SetBool("WalkR",false);
						anim.SetBool("WalkF",false);
						anim.SetBool("WalkB",true);
					}
				}
			}
		}
	}
	
	public void OnTriggerEnter2D(Collider2D c)
	{
		if(c.gameObject.tag == "Rock")
		{
			takeDamage();
			Destroy(c.gameObject);
		}
	}
}
