using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {
	float lifeTime = 1.0f;
	public CharMove moveScript;
	public float throwSpeed;
	// Use this for initialization
	void Start () 
	{

		Destroy (this.gameObject,lifeTime);
	}
	
	// Update is called once per frame
	void Update () 
	{

		moveScript = GameObject.Find("GJ1_CharacterWalk_L").GetComponent<CharMove>();

		if (moveScript.leftFace == true)
		transform.Translate  (Vector3.left * throwSpeed);

		if (moveScript.backFace == true)
			transform.Translate  (Vector3.up * throwSpeed);

		if (moveScript.backFace == true)
			transform.Translate  (Vector3.up * throwSpeed);

		if (moveScript.rightFace == true)
			transform.Translate  (Vector3.right * throwSpeed);
			

	}

	void SpawnRock()
	{

	}
}
