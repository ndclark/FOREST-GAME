using UnityEngine;
using System.Collections;

public class marioControllerScript : MonoBehaviour 
{

	public float maxSpeed = 10f;
	bool faceRight = true;
	public GameObject shootObject;
	GameObject shootSoundObject;
	GameObject[] NofP;

	Animator anim;
	bool grounded = false;
	bool doPunch = false;
	bool shoot = true;

	float shootTimer = 1;
	float groundRadius = 0.2f;

	public int shootR = 0;
	public LayerMask whatIsGround;
	public float jumpForce = 700;
	public Transform groundCheck;


	void Awake ()
	{

	}

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground",grounded);





		anim.SetFloat("vSpeed",rigidbody2D.velocity.y);


		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("speed",Mathf.Abs (move));

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);


		if(move > 0 && !faceRight)
			Flip();
		else if (move < 0 && faceRight)
			Flip ();


	}

	void Update()
	{

		if (Input.GetKey(KeyCode.LeftArrow))
			shootR = 1;
		else if (Input.GetKey(KeyCode.RightArrow))
			shootR = 0;


		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground",false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}


		if ( Input.GetKeyDown(KeyCode.Z))
		{

			anim.SetBool("doPunch",false);
			Instantiate(shootObject, transform.position +new Vector3(0,0,0),Quaternion.Euler(0,0,0));

		}
		else
			anim.SetBool("doPunch",false);
	}
	

	
	void Flip()
	{
		faceRight = !faceRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}



}