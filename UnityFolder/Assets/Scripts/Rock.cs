using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {
	float lifeTime = 1.0f;
	public CharMove moveScript;
	public float throwSpeed;
	bool directionL;
	bool directionR;
	bool directionU;
	bool directionD;
	// Use this for initialization
	void Start () 
	{
		moveScript = GameObject.Find("GJ1_CharacterWalk_L").GetComponent<CharMove>();
		directionL = moveScript.leftFace;
		directionR = moveScript.rightFace;
		directionU = moveScript.backFace;
		directionD = moveScript.frontFace;
		Destroy (this.gameObject,lifeTime);
	}
	
	// Update is called once per frame
	void Update () 
	{



		if (directionL)
		transform.Translate  (Vector3.left * throwSpeed);

		if (directionU)
			transform.Translate  (Vector3.up * throwSpeed);

		if (directionD)
			transform.Translate  (Vector3.down * throwSpeed);

		if (directionR)
			transform.Translate  (Vector3.right * throwSpeed);
			

	}

	void SpawnRock()
	{

	}
}
