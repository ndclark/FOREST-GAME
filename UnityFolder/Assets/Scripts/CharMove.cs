using UnityEngine;
using System.Collections;

public class CharMove : MonoBehaviour {
	public float vertSpeed = 0.0f;
	public float horzSpeed = 0.0f;

	public bool leftFace;
	public bool rightFace;
	public bool frontFace;
	public bool backFace;

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate () 
	{
		 Vector2 targetDirection = Vector2.zero;
		if (Input.GetKey (KeyCode.A))
		{
			anim.SetBool("WalkB",false);
			anim.SetBool("WalkR",false);
			anim.SetBool("WalkF",false);
			anim.SetBool("WalkL",true);



			frontFace = false;
			backFace = false;
			rightFace = false;
			leftFace = true;
			targetDirection += -Vector2.right*horzSpeed;
		}
		else if (Input.GetKey (KeyCode.D))
		{
			anim.SetBool("WalkL",false);
			anim.SetBool("WalkB",false);
			anim.SetBool("WalkF",false);
			anim.SetBool("WalkR",true);


			leftFace = false;
			frontFace = false;
			backFace = false;
			rightFace = true;
			targetDirection += Vector2.right*horzSpeed;
		}
		else if (Input.GetKey (KeyCode.W))
		{
			anim.SetBool("WalkL",false);
			anim.SetBool("WalkR",false);
			anim.SetBool("WalkF",false);
			anim.SetBool("WalkB",true);


			leftFace = false;
			backFace = false;
			rightFace = false;
			backFace = true;
			targetDirection += Vector2.up *vertSpeed;
		}
		else if (Input.GetKey (KeyCode.S))
		{

			anim.SetBool("WalkL",false);
			anim.SetBool("WalkR",false);
			anim.SetBool("WalkB",false);
			anim.SetBool("WalkF",true);

			leftFace = false;
			rightFace = false;
			backFace = false;
			frontFace = true;
			targetDirection += -Vector2.up * vertSpeed;

		}
		else
		{
			anim.SetBool("WalkB",false);
			anim.SetBool("WalkL",false);
			anim.SetBool("WalkR",false);
			anim.SetBool("WalkF",false);
		}
	

		rigidbody2D.velocity = targetDirection * Time.deltaTime;
	}




}
