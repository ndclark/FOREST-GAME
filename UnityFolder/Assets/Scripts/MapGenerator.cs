using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{
	public GameObject boundryTree, tree1, tree2, foodTree, bush1, bush2, foodBush;
	public int boundryWide, boundryHigh;
	public float percentChanceTree, treePercentClump;
	public int maxClumpSize, maxTree;
	private float minX, maxX, minY, maxY;
	private float imgWidth, imgHeight;
	
	// Use this for initialization
	void Start ()
	{
		create ();
	}
	
	void create()
	{
		Vector3 imgTR = tree1.GetComponent<SpriteRenderer>().sprite.bounds.min,
		imgBR = tree1.GetComponent<SpriteRenderer>().sprite.bounds.max;
		imgWidth = tree1.transform.lossyScale.x * (imgBR.x - imgTR.x);
		imgHeight = tree1.transform.lossyScale.y * (imgTR.y-imgBR.y);
		minX = imgWidth;
		maxX = imgWidth * (boundryWide-1);
		minY = imgHeight;
		maxY = imgHeight * (boundryHigh-1);
		boundry ();
		trees ();
	}
	
	//Generates the boundry 
	void boundry()
	{
		
		Vector3 imgTR = tree1.GetComponent<SpriteRenderer>().sprite.bounds.min,
			imgBR = tree1.GetComponent<SpriteRenderer>().sprite.bounds.max;
		
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
	
	//Dis makes da trees
	void trees()
	{
	for(int it = 0; it < 30 && maxTree > 0; ++it)
		if(percentChanceTree <= Random.Range(0f,1f))
		{
			if(percentChanceTree <= Random.Range(0f,1f))
			{
				Vector2 clumpRoot = new Vector2(Random.Range(minX,maxX),Random.Range (minY,maxY));
				int numTrees = Random.Range(1,5);
				for(int i = 0; i < numTrees; ++i)
				{
					Instantiate(tree1,new Vector3(clumpRoot.x+Random.Range (-3f,3f),clumpRoot.y+Random.Range (-3f,3f),1),Quaternion.identity);
				}
				maxTree-= numTrees;
			}
			else
			{
				Instantiate(tree1,new Vector3(Random.Range (minX,maxX),Random.Range (minY,maxY),1f),Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
