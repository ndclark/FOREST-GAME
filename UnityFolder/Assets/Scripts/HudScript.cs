﻿using UnityEngine;
using System.Collections;

public class HudScript : MonoBehaviour {

	// Use this for initialization
	public float Player_Health = 100f;
	public float Player_Water = 100f;
	public float Player_Food = 100f;
	public int Rocks_Carried = 0;
	public int Stick_Carried = 0;

	public float Health_Fall;
	public float Water_Fall;
	public float Food_Fall;
	public GUIStyle Health_Bar_GUI;
	public GUIStyle Water_Bar_GUI;
	public GUIStyle Food_Bar_GUI;

	// Update is called once per frame
	void Update () 
	{
		Player_Water = Player_Water - Water_Fall;
		Player_Food = Player_Food - Food_Fall;

		if (Player_Water > 100) 
			Player_Water = 100;

		if (Player_Food > 100) 
			Player_Food = 100;

		if (Player_Water <= 0)
		{
			Player_Water = 0;
			Player_Health = Player_Health - Health_Fall;
		}

		if (Player_Food <= 0)
		{
			Player_Food = 0;
			if(Player_Water <= 0)
			Player_Health = Player_Health - Health_Fall;
			else
				Player_Health = Player_Health - Food_Fall;
		}

		if (Player_Health <= 0)
		{
			Player_Health =0;
			Application.LoadLevel(2);
		}
	
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10,80,100, 30) , "Rock: " + (Rocks_Carried));
		GUI.Box (new Rect (5, 5, Screen.width / 3/ ( 100 / Player_Health) , 20), "" + (int)Player_Health, Health_Bar_GUI);
		GUI.Box (new Rect (5, 30, Screen.width / 3/ ( 100 / Player_Water) , 20), "" + (int)Player_Water, Water_Bar_GUI);
		GUI.Box (new Rect (5, 60, Screen.width / 3/ ( 100 / Player_Food) , 20), "" + (int)Player_Food, Food_Bar_GUI);
	}
}
