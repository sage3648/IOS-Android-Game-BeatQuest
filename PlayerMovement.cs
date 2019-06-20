using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerMovement : MonoBehaviour
{

	public Vector2 MousePosition;
	public Vector2 PlayerPosition;
	public AudioSource BackgroundMusic;
	public float PreviousTimeTotal;
	public float CurrentTimeTotal;
	public float MusicDeltaTime; //universal delta
	public float LevelDistance; 
	public GameObject DashEffectLeft,DashEffectRight;
	public GameObject DashEffectSaiyan;
	private int _levelSelector;
	public GameObject MoveLeft, MoveRight,MoveRight1,MoveRight2,MoveRight3,MoveLeft1,MoveLeft2,MoveLeft3;
	public GameObject DashMarker; 
		
	// Update is called once per frame


	private void DashMovement(Vector3 currentPos, Vector3 targetPos, bool movingTowardsTarget)
	{
		float difference = targetPos.x - currentPos.x;
		//float cloneCalc = difference / 0.4f;
		//int steps = (int)cloneCalc; 
		if (movingTowardsTarget)
		{
			
			//move right
			if (targetPos.x > currentPos.x)
			{
				//movingTowardsTarget = true; 
				GameObject dashMarker = Instantiate(DashMarker, currentPos, transform.rotation);
				dashMarker.transform.position = Vector3.MoveTowards(dashMarker.transform.position, targetPos, 0.4f);
				currentPos = dashMarker.transform.position;

				int rand = Random.Range(1,4);
				switch (rand)
				{
					case 1:
						Instantiate(MoveRight, currentPos, transform.rotation);
						break;
					case 2:
						Instantiate(MoveRight1, currentPos, transform.rotation);

						break; 
					case 3:
						Instantiate(MoveRight2, currentPos, transform.rotation);

						break; 
					case 4:
						Instantiate(MoveRight3, currentPos, transform.rotation);
						break; 
					
				}
				

				if (currentPos.x >= targetPos.x)
				{
					movingTowardsTarget = false;
				}
				else
				{
					DashMovement(currentPos,targetPos,movingTowardsTarget);
				}
			}
			//move left
			else
			{
				GameObject dashMarker = Instantiate(DashMarker, currentPos, transform.rotation);
				dashMarker.transform.position = Vector3.MoveTowards(dashMarker.transform.position, targetPos, 0.4f);
				currentPos = dashMarker.transform.position;

				int rand = Random.Range(1,4);
				switch (rand)
				{
					case 1:
						Instantiate(MoveLeft, currentPos, transform.rotation);
						break;
					case 2:
						Instantiate(MoveLeft1, currentPos, transform.rotation);

						break;
					case 3:
						Instantiate(MoveLeft2, currentPos, transform.rotation);

						break;
					case 4:
						Instantiate(MoveLeft3, currentPos, transform.rotation);
						break;

				}

				if (currentPos.x <= targetPos.x)
				{
					movingTowardsTarget = false;
				}
				else
				{
					DashMovement(currentPos,targetPos,movingTowardsTarget);
				}
			}

		}
		
	
		
	}
	private void Start()
	{
		_levelSelector = Camera.main.GetComponentInChildren<ScoreHandler>().LevelSelected; 
	}

	void Update ()
	{
		
		CurrentTimeTotal = BackgroundMusic.time; 
		PlayerPosition = transform.position;
		MusicDeltaTime = GetMusicDeltaTime(CurrentTimeTotal, PreviousTimeTotal);
		switch (_levelSelector)
		{
				case 1:
					PlayerPosition.y += 6f * GetMusicDeltaTime(CurrentTimeTotal, PreviousTimeTotal);
					break;
				case 2:
					PlayerPosition.y += 10f * GetMusicDeltaTime(CurrentTimeTotal, PreviousTimeTotal);
					break; 
		}
		
		
		//may not work as well 
		//transform.position = Vector2.MoveTowards(transform.position, PlayerPosition, 4f); //   PlayerPosition; 
		transform.position = PlayerPosition; 
		//MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		//MousePosition.y = PlayerPosition.y; 

		
		//Touch input takes as many touchs as registered
		for (int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				//Vector3 location = Input.mousePosition;
				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
				//Ray castPoint = Camera.main.ScreenPointToRay(mouse);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, Mathf.Infinity))
				{
					DashMovement(transform.position,new Vector3(hit.point.x,transform.position.y,transform.position.z),true);
					transform.position = new Vector2(hit.point.x,transform.position.y); 
					transform.GetComponentInChildren<PlayerAnimationController>().AttackEvent();
					//= hit.point; 
				}
				
				if (hit.point.y > transform.position.y)
				{
					if (transform.GetComponent<PlayerAnimationController>().Saiyan)
					{
						Instantiate(DashEffectSaiyan, transform.position, transform.rotation); 
					}
					else
					{
						Instantiate(DashEffectRight, transform.position, transform.rotation); 
					}
				}
				else
				{	
					if (transform.GetComponent<PlayerAnimationController>().Saiyan)
					{
						Instantiate(DashEffectSaiyan, transform.position, transform.rotation); 
					}
					else
					{
						Instantiate(DashEffectLeft, transform.position, transform.rotation); 
					} 
				}
			}
		}
		
		//To be replaced with touch inputs
		/*if (Input.GetMouseButtonDown(0))
		{
			//this shit is to create the dash effect later, when we're less gacked 
			if (MousePosition.y > transform.position.y)
			{
				if (transform.GetComponent<PlayerAnimationController>().Saiyan)
				{
					Instantiate(DashEffectSaiyan, transform.position, transform.rotation); 
				}
				else
				{
					Instantiate(DashEffectRight, transform.position, transform.rotation); 
				}
			}
			else
			{	
				if (transform.GetComponent<PlayerAnimationController>().Saiyan)
				{
					Instantiate(DashEffectSaiyan, transform.position, transform.rotation); 
				}
				else
				{
					Instantiate(DashEffectLeft, transform.position, transform.rotation); 
				} 
			}
			
			Plane plane = new Plane(Vector3.up, 0);
			Vector3 move = new Vector3(); 

			/*float dist;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (plane.Raycast(ray, out dist))
			{

				Vector3 mousePos = ray.GetPoint(dist);
				transform.position = mousePos; 
				Debug.Log("MousePosition is" + mousePos);	
			}*/

			//Movement in 2D space
			//transform.position = MousePosition; 
			//Vector3 MousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			//transform.position = new Vector3(MousePos.x,transform.position.y,transform.position.z);
		/*	Vector3 mouse = Input.mousePosition;
			Ray castPoint = Camera.main.ScreenPointToRay(mouse);
			RaycastHit hit;
			if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
			{
				transform.position = new Vector2(hit.point.x,transform.position.y); 
					//= hit.point; 
			}
		}*/
		//for playing on pc & debugging
		
		//was originally else if
		if (Input.GetButtonDown("Fire1"))
		{
			//this shit is to create the dash effect later, when we're less gacked 
			if (MousePosition.y > transform.position.y)
			{
				if (transform.GetComponent<PlayerAnimationController>().Saiyan)
				{
					//Instantiate(DashEffectSaiyan, transform.position, transform.rotation); 
				}
				else
				{
					//Instantiate(DashEffectRight, transform.position, transform.rotation); 
				}
				//Instantiate(DashEffectRight, transform.position, transform.rotation); 
			}
			else
			{	
				if (transform.GetComponent<PlayerAnimationController>().Saiyan)
				{
					//Instantiate(DashEffectSaiyan, transform.position, transform.rotation); 
				}
				else
				{
					//Instantiate(DashEffectRight, transform.position, transform.rotation); 
				}
			}
			Vector3 mouse = Input.mousePosition;
			Ray castPoint = Camera.main.ScreenPointToRay(mouse);
			RaycastHit hit;
			if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
			{
				GameObject[] DashObjects;
				DashObjects = GameObject.FindGameObjectsWithTag("Dash");
				foreach (GameObject g in DashObjects)
				{
					Destroy(g);
				}
				DashMovement(transform.position,new Vector3(hit.point.x,transform.position.y,transform.position.z), true);
				transform.position = new Vector2(hit.point.x,transform.position.y); 

				//= hit.point; 
			}
			//transform.position = MousePosition;  
		}
		
	}

	private void LateUpdate()
	{
		PreviousTimeTotal = CurrentTimeTotal;
		if (transform.position.y >= LevelDistance)
		{
			Camera.main.GetComponentInChildren<ScoreHandler>().GameEnding = true; 
		}
	}

	public float GetMusicDeltaTime(float currentTime, float previousTime)
	{
		float delta = currentTime - previousTime;
		return delta; 
	}
}
