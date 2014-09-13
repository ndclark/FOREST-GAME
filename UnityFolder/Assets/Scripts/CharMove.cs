using UnityEngine;
using System.Collections;

public class CharMove : MonoBehaviour {
	public float vertSpeed = 0.0f;
	public float horzSpeed = 0.0f;

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.A))
			anim.SetBool("WalkL",true);
	}

	void FixedUpdate () 
	{
		Vector2 targetDirection = Vector2.zero;
		if (Input.GetKey (KeyCode.A))
		{
			anim.SetBool("WalkL",true);
			targetDirection += -Vector2.right*horzSpeed;
		}
		else if (Input.GetKey (KeyCode.D))
		{
			anim.SetBool("WalkR",true);
			targetDirection += Vector2.right*horzSpeed;
		}
		else if (Input.GetKey (KeyCode.W))
			targetDirection += Vector2.up *vertSpeed;
		else if (Input.GetKey (KeyCode.S))
			targetDirection += -Vector2.up * vertSpeed;
		else
		{
			anim.SetBool("WalkL",false);
			anim.SetBool("WalkR",false);
		}
	

		rigidbody2D.velocity = targetDirection * Time.deltaTime;
	}



}
