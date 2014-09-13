﻿using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

	// Use this for initialization
	 float Player_Health = 100f;
	 float Player_Water = 100f;

	public float Health_Fall;

	public GUIStyle Health_Bar_GUI;
	public GUIStyle Water_Bar_GUI;
	
	// Update is called once per frame
	void Update () 
	{
		Player_Water = Player_Water - Health_Fall;

		if (Player_Water <= 0)
		{
			Player_Water = 0;
			Player_Health = Player_Health - Health_Fall;
		}
	
	}

	void OnGUI()
	{
		GUI.Box (new Rect (5, 5, Screen.width / 3/ ( 100 / Player_Health) , 20), "" + (int)Player_Health, Health_Bar_GUI);
		GUI.Box (new Rect (5, 30, Screen.width / 3/ ( 100 / Player_Water) , 20), "" + (int)Player_Water, Water_Bar_GUI);
	}
}
