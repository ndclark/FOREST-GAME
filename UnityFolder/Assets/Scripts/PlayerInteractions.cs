using UnityEngine;
using System.Collections;

public class PlayerInteractions : MonoBehaviour {

	public delegate void DrinkAction();
	public static event DrinkAction OnDrink;
	public delegate void EatAction();
	public static event EatAction OnEat;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D (Collision2D col) 
	{

		if(col.gameObject.tag.Contains("Drinkable"))
		{
			if(OnDrink!=null)
			{
				OnDrink();
			}
		}

		if(col.gameObject.tag.Contains("Eatable"))
		{
			if(OnEat!=null)
			{
				OnEat();
			}
		}

	}

}
