using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {
	float lifeTime = 1.0f;
	// Use this for initialization
	void Start () 
	{
		Destroy (this.gameObject,lifeTime);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate  (new Vector3(20,0,0) * Time.deltaTime);

	}

	void SpawnRock()
	{

	}
}
