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
	
	void Awake()
	{
		t = -minDirectionChangeTime;
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
						transform.Translate(-speed * Time.deltaTime, 0f, 0f);
					else
						transform.Translate(speed * Time.deltaTime, 0f, 0f);
				}
				else
				{
					//Move along Y
					if(neededMov.y < 0)
						transform.Translate(0f, -speed * Time.deltaTime, 0f);
					else
						transform.Translate(0f, speed * Time.deltaTime, 0f);
				}
			}
		}
	}
}
