﻿using UnityEngine;
using System.Collections;

public class PlayerInteractions : MonoBehaviour {
	
	public HudScript hudScript;
	public float drinkRate;
	public float eatAmount;
	bool paused = false;

	public GameObject rockObject;
	// Use this for initialization
	void Start () 
	{
		hudScript = GameObject.Find("Main Camera").GetComponent<HudScript>();


	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetKeyDown (KeyCode.Space) && hudScript.Rocks_Carried == 1)
		{
			Instantiate(rockObject, transform.position +new Vector3(0,0,0),Quaternion.Euler(0,0,0));
			hudScript.Rocks_Carried = 0;
		}


		if(Input.GetKeyDown(KeyCode.Escape))
			paused = togglePause();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Rock")
		{
			if (hudScript.Rocks_Carried == 0)
			{
				hudScript.Rocks_Carried = 1;
				Destroy (other.gameObject);
			}

		}

		if (other.gameObject.tag == "Stick")
		{
			Debug.Log("PickedUpStick");
			if(hudScript.Stick_Carried == 0)
			{
				hudScript.Stick_Carried = 1;
				//visual effect of carrying stick?
				Destroy (other.gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		
		if (other.gameObject.tag == "Food")
		{
			Debug.Log("Eating");
			hudScript.Player_Food = hudScript.Player_Food + eatAmount;
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "Rock")
		{	
			
			if(hudScript.Rocks_Carried == 0)
			{
				Debug.Log("PickedUpRock");
				hudScript.Rocks_Carried = 1;

			}
		}

	} 

	void OnCollisionStay2D(Collision2D other)
	{

		if (other.gameObject.tag == "Water")
		{
			Debug.Log("Drinking");
			hudScript.Player_Water = hudScript.Player_Water + drinkRate;
		}

	}

	void OnGUI ()
	{
		if(paused)
		{
			GUILayout.Label("Game is paused!");
			if(GUILayout.Button("Click me to unpause"))
				paused = togglePause();
		}
	}

	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);
		}
	}
}



