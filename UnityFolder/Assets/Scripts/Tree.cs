using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	public float vertOffset, leftOffset, rightOffset, transparentAlpha;
	BoxCollider2D boxCollider;
	float boxColliderTop;
	float playerY;
	float playerX;
	float playerWidth;
	float treeWidth;
	GameObject player;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		boxCollider = gameObject.GetComponent<BoxCollider2D>();
		boxColliderTop = boxCollider.bounds.min.y;
		playerY = player.transform.position.y;
		playerX = player.transform.position.x;
		playerWidth = player.GetComponent<SpriteRenderer>().sprite.bounds.max.x - player.GetComponent<SpriteRenderer>().sprite.bounds.min.x;
		treeWidth = transform.lossyScale.x * (gameObject.GetComponent<SpriteRenderer>().sprite.bounds.max.x - gameObject.GetComponent<SpriteRenderer>().sprite.bounds.min.x);
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerY = player.transform.position.y;
		playerX = player.transform.position.x;
		bool isAbove = playerY + vertOffset > boxColliderTop; //Vertical check 
		bool isInLeftBound = playerX + playerWidth + leftOffset > gameObject.transform.position.x;
		bool isInRightBound = playerX + rightOffset < transform.position.x + treeWidth;
		Debug.Log("TreeY: " + boxColliderTop + "\tPlayerY: " + playerY);
		if(isAbove && isInLeftBound && isInRightBound)
		{
			gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,transparentAlpha);
		}
		else
		{
			gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
		}
	}
}
