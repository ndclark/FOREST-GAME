using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour {

	public int NumSticks;
	public GameObject player;
	public HudScript hudScript;
	public bool onFire;
	public Animator anim;

	// Use this for initialization
	void Start () {
		NumSticks = 1;
	}

	void Awake () 
	{
		NumSticks = 1;
		onFire = false;
		player = GameObject.FindGameObjectWithTag ("Player");
		hudScript = GameObject.Find ("Main Camera").GetComponent<HudScript> ();
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
				if (hudScript.Stick_Carried == 1)
				{
					//place stick
					hudScript.Stick_Carried = 0;
					NumSticks ++;
				}
				if (hudScript.Stick_Carried == 2)
				{
					//place flaming stick
					hudScript.Stick_Carried = 0;
					NumSticks ++;
					onFire = true;
				}
			}
		}

		if (Input.GetMouseButton (0)) 
		{
			if (Vector3.Distance (transform.position, player.transform.position) <= 2) 
			{
				if (hudScript.Stick_Carried == 1 && onFire)
				{
					//light stick
					hudScript.Stick_Carried = 2;
				}

				if (hudScript.Stick_Carried == 0)
				{
					//take stick
					hudScript.Stick_Carried = 1;
					if (onFire) hudScript.Stick_Carried = 2;
					NumSticks --;
				}
			}
		}


	}
}
