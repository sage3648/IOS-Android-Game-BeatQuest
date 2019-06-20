using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	private Vector3 _cameraPosition; 

	// Update is called once per frame
	void Update ()
	{
		_cameraPosition = Camera.main.transform.position;
		Vector2 _playerPostion = transform.GetComponentInChildren<PlayerMovement>().PlayerPosition;
		_cameraPosition.y = _playerPostion.y;
		_cameraPosition.y += 1.5f;
		//_cameraPosition.z = -10f;
		//_cameraPosition.y -= -3f; 


		//Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, _cameraPosition, 4f);
		
		
		Camera.main.transform.position = _cameraPosition; 
	}
}
