using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStory : MonoBehaviour
{
	Vector2 Target;
	private bool _stop; 

	// Start is called before the first frame update
	void Start()
	{
		Target = gameObject.transform.position;

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_stop = false; 
			Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			float verticalDifference = transform.position.y - Target.y;
			float horizontalDifference = transform.position.x - Target.x;
			if (verticalDifference > horizontalDifference)
			{
				//moving up
				transform.GetComponentInChildren<Animator>().SetTrigger("MoveRight");
			}
			else
			{
				transform.GetComponentInChildren<Animator>().SetTrigger("MoveUp");

				//moving right
			}
		}

		if (!_stop)
		{
			gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Target, 0.04f);
		}
		
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		_stop = true;
	}
}

