using UnityEngine;
using System.Collections;

public class Boar_AI : MonoBehaviour
{
	public GameObject player = null;
	public float attackDistance;
	public float speed;
	public float minDirectionChangeTime, senseDistance;
	private float boarWidth, boarHeight;
	private bool isMovingX = false;
	private float t;
	public GameObject boardBaby;
	Animator anim;
	
	void Awake()
	{
		t = -minDirectionChangeTime;
		anim = GetComponent <Animator>();
		if(player == null)
			player = GameObject.FindGameObjectWithTag("Player");
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
				//ATTACK TODO
				if( t > minDirectionChangeTime)
				{
					Instantiate(boardBaby, player.transform.position, Quaternion.identity);
					t = 0f;
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
}
