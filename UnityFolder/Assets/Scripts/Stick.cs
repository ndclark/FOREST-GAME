using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour 
{

	public HudScript hudScript;
	public GameObject player;

	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		hudScript = GameObject.Find ("Main Camera").GetComponent<HudScript> ();
	}

	void OnMouseOver ()
	{
		
		if (Input.GetMouseButton (1))
		{
			if (Vector3.Distance (transform.position, player.transform.position) <= 2) 
			{
				if (hudScript.Stick_Carried == 1) 
				{
					//create unlit campfire
					hudScript.Stick_Carried = 0;

				}
				if (hudScript.Stick_Carried == 2) 
				{
					//crate lit campfire
				
				}
			}
		}
	}
}
