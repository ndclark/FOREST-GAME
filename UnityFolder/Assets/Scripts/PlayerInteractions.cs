using UnityEngine;
using System.Collections;

public class PlayerInteractions : MonoBehaviour {
	
	public HudScript hudScript;
	public float drinkRate;
	public float eatAmount;

	public GameObject rockObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		hudScript = GameObject.Find("Main Camera").GetComponent<HudScript>();
		if( Input.GetKeyDown (KeyCode.Space) && hudScript.Rocks_Carried == 1)
		{
			Instantiate(rockObject, transform.position +new Vector3(0,0,0),Quaternion.Euler(0,0,0));
			hudScript.Rocks_Carried = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		
		if (other.gameObject.tag == "Food")
		{
			Debug.Log("Eating");
			hudScript = GameObject.Find("Main Camera").GetComponent<HudScript>();
			hudScript.Player_Food = hudScript.Player_Food + eatAmount;
			Destroy (other.gameObject);
		}
		
		if (other.gameObject.tag == "Rock")
		{
			Debug.Log("PickedUpRock");
			hudScript = GameObject.Find("Main Camera").GetComponent<HudScript>();
			hudScript.Rocks_Carried += 1;
			Destroy (other.gameObject);
		}
	} 

	void OnCollisionStay2D(Collision2D other)
	{

		if (other.gameObject.tag == "Water")
		{
			Debug.Log("Drinking");
			hudScript = GameObject.Find("Main Camera").GetComponent<HudScript>();
			hudScript.Player_Water = hudScript.Player_Water + drinkRate;
		}

	}


}
