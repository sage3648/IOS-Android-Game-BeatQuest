using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMover : MonoBehaviour
{
	public GameObject Player; 
	private Vector2 PlayerPosition; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		PlayerPosition = Player.transform.position;
		PlayerPosition.x = 0;
		PlayerPosition.y += 0.6f;
		transform.position = PlayerPosition; 
	}
}
