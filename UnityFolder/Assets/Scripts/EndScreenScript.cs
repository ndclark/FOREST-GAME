using UnityEngine;
using System.Collections;

public class EndScreenScript : MonoBehaviour {

	public Texture backgroundTexture;
	public GUIStyle startButton;
	public GUIStyle quitButton;
	public float guiPlacementY1;
	public float guiPlacementY2;
	public float guiPlacementX1;
	public float guiPlacementX2;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundTexture);
		
		if(GUI.Button(new Rect(Screen.width * guiPlacementX1 ,Screen.height * guiPlacementY1,Screen.width * .25f, Screen.height * .1f),"",startButton))
		{
			Application.LoadLevel(1);
		}
		
		if(GUI.Button(new Rect(Screen.width * guiPlacementX2 ,Screen.height * guiPlacementY2,Screen.width * .25f, Screen.height * .1f),"",quitButton))
		{
			Debug.Break();
		}


	}

}
