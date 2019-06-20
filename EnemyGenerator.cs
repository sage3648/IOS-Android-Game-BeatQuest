using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple monster spawner pre boss mechanics

public class EnemyGenerator : MonoBehaviour
{
	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public GameObject Enemy4;
	public GameObject Enemy5;
	public Vector2[] Locations;
	public GameObject Player;
	public GameObject LeftTorch, RightTorch;
	public AudioSource AudioSource;
	public AudioSource Infront;
	private float _timer; 
	private bool _firstNote;
	private float SongTime;
	private float _targerTime; 
	private float counter; 
	
	// Use this for initialization
	void Start ()
	{
		_timer = 3.15f; 
		_firstNote = true; 
		counter = 0;
		_targerTime = 1.85f; 
	}
	// Update is called once per frame
	void Update ()
	{
		
		SongTime = AudioSource.time;
		//Debug.Log(SongTime);
		//_targerTime = SongTime + 0.45112781954887218f;
		
		
		//temporarily in place on MIDI reading to decide location
		int location = Random.Range(1, 4);
		int enemyType = Random.Range(1, 4);

		if (SongTime >= _targerTime)
		{
			switch (enemyType)
			{
					case 1:
						if (counter >= 2 || _firstNote)
						{
							_firstNote = false;
							Instantiate(LeftTorch, new Vector2(-2.165f, Player.transform.position.y + 10),
								transform.rotation); 
							Instantiate(RightTorch, new Vector2(2.165f, Player.transform.position.y + 10),
								transform.rotation); 
							Instantiate(Enemy1, new Vector2(Locations[location].x, Player.transform.position.y + 10),
								transform.rotation);
							counter = 0; 
						}
						else
						{
							Instantiate(Enemy1, new Vector2(Locations[location].x, Player.transform.position.y + 10),
								transform.rotation);
							location = Random.Range(0, 5);
							//Instantiate(Enemy1, new Vector2(Locations[location].x, Player.transform.position.y + 10),
							//transform.rotation);
						}
						break;
					case 2:
						if (counter >= 2 || _firstNote)
						{
							_firstNote = false;
							Instantiate(LeftTorch, new Vector2(-2.165f, Player.transform.position.y + 10),
								transform.rotation); 
							Instantiate(RightTorch, new Vector2(2.165f, Player.transform.position.y + 10),
								transform.rotation); 
							Instantiate(Enemy2, new Vector2(Locations[location].x, Player.transform.position.y + 10),
								transform.rotation);
							counter = 0; 
						}
						else
						{
							Instantiate(Enemy2, new Vector2(Locations[location].x, Player.transform.position.y + 10),
								transform.rotation);
							location = Random.Range(0, 5);
							//Instantiate(Enemy1, new Vector2(Locations[location].x, Player.transform.position.y + 10),
						}
						break;
					case 3:
						if (counter >= 2 || _firstNote)
						{
							_firstNote = false;
							Instantiate(LeftTorch, new Vector2(-2.165f, Player.transform.position.y + 10),
								transform.rotation); 
							Instantiate(RightTorch, new Vector2(2.165f, Player.transform.position.y + 10),
								transform.rotation); 
							Instantiate(Enemy3, new Vector2(Locations[location].x, Player.transform.position.y + 10),
								transform.rotation);
							counter = 0; 
						}
						else
						{
							Instantiate(Enemy3, new Vector2(Locations[location].x, Player.transform.position.y + 10),
								transform.rotation);
							location = Random.Range(0, 5);
							//Instantiate(Enemy1, new Vector2(Locations[location].x, Player.transform.position.y + 10),
							//transform.rotation);
						}
						break;
			}

			if (AudioSource.time >= 90f)
			{
				//_targerTime += 0.2255639098f; 
			}
			else
			{
				_targerTime += 0.33898305084745763f;
				//_targerTime += 0.45112781954887218f;
			}
			counter++; 
		
		}
	}
}
