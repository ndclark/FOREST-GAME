using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{
	public GameObject tree1, tree2, foodTree, bush1, bush2, foodBush;
	public int boundryWide, boundryHigh;
	
	// Use this for initialization
	void Start ()
	{
		create ();
	}
	
	void create()
	{
		boundry ();
	}
	
	void boundry()
	{
		
		Vector3 imgTR = tree1.GetComponent<SpriteRenderer>().sprite.bounds.min,
			imgBR = tree1.GetComponent<SpriteRenderer>().sprite.bounds.max;
		float imgWidth = tree1.transform.lossyScale.x * (imgBR.x - imgTR.x), imgHeight = tree1.transform.lossyScale.y * (imgTR.y-imgBR.y);
		//Create top row and bottom row
		for(int x = 0; x < boundryWide; ++x)
		{
			//Top Tree
			Instantiate(tree1,new Vector3(x*imgWidth,0,0),Quaternion.identity);
			//Bottom Tree
			Instantiate(tree1,new Vector3(x*imgWidth,(boundryHigh-1)*imgHeight,0),Quaternion.identity);
		}
		
		//Create left column and right column
		for(int y = 0; y < boundryWide; ++y)
		{
			//Left Tree
			Instantiate(tree1,new Vector3(0,y*imgHeight,0),Quaternion.identity);
			//Right Tree
			Instantiate(tree1,new Vector3((boundryHigh-1)*imgWidth,y*imgHeight,0),Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
