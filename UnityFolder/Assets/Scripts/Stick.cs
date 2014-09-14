using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour {

	public int NumSticks;
	public GameObject player;
	public bool onFire;

	// Use this for initialization
	void Start () {
	
	}

	void Awake () 
	{
		NumSticks = 1;
		onFire = false;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		if (NumSticks == 0)
			Destroy (this.gameObject);
		//animation depending on numsticks/fire

	}

	void OnMouseOver ()
	{

		if (Input.GetMouseButton (1)) 
		{
			if (Vector3.Distance (transform.position, player.transform.position) <= 2) 
			{
				if (player.HudScript.Stick_Carried == 1)
				{
					//place stick
					player.HudScript.Stick_Carried = 0;
					NumSticks ++;
				}
				if (player.HudScript.Stick_Carried == 2)
				{
					//place flaming stick
					player.HudScript.Stick_Carried = 0;
					NumSticks ++;
					onFire = true;
				}
			}
		}

		if (Input.GetMouseButton (0)) 
		{
			if (Vector3.Distance (transform.position, player.transform.position) <= 2) 
			{
				if (player.HudScript.Stick_Carried == 1 && onFire)
				{
					//light stick
					player.HudScript.Stick_Carried = 2;
				}

				if (player.HudScript.Stick_Carried == 0)
				{
					//take stick
					player.HudScript.Stick_Carried = 1;
					NumSticks --;
				}
			}
		}


	}
}
