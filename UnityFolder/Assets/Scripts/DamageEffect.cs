using UnityEngine;
using System.Collections;

public class DamageEffect : MonoBehaviour {

	public Color damageColor;
	private SpriteRenderer sr;
	private float t = 0f;
	private bool run;
	
	public void Init()
	{
		sr = gameObject.GetComponent<SpriteRenderer>();
		sr.color = damageColor;
		run = true;
		t=0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(run)
		{
			t+=Time.deltaTime;
			sr.color = Color.Lerp(damageColor,Color.white,t);
			if(t>1.0f)
			{
				run=false;
			}
		}	
	}
}
