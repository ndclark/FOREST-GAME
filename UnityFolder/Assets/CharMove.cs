using UnityEngine;
using System.Collections;

public class CharMove : MonoBehaviour {
	public float vertSpeed = 0.0f;
	public float horzSpeed = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () 
	{
		Vector2 targetDirection = Vector2.zero;
		if (Input.GetKey (KeyCode.A))
			targetDirection += -Vector2.right*horzSpeed;
		else if (Input.GetKey (KeyCode.D))
			targetDirection += Vector2.right*horzSpeed;
		else if (Input.GetKey (KeyCode.W))
			targetDirection += Vector2.up *vertSpeed;
		else if (Input.GetKey (KeyCode.S))
			targetDirection += -Vector2.up * vertSpeed;
	

		rigidbody2D.velocity = targetDirection * Time.deltaTime;
	}
}
