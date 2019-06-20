using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class TimeLock : MonoBehaviour
{
	public GameObject Indicator;
	public GameObject Player;
	public AudioSource AudioSource;
	private float _targerTime; 
	private float SongTime;
	private GameObject _go;
	public bool DebugMode;
	public int level; 
	
	
	// Use this for initialization
	void Start ()
	{
		//originally 1.73f, which is perfect on PC, but I am experimenting with adjustments for Android/IOS 
		switch (level)
		{
			case 1:
				_targerTime = 0f;

				//_targerTime += 0.915f;
				//_targerTime += 1.83f;
				break;
			case 2:
				//_targerTime = 1.83f; 
				_targerTime = 0f; 
				break; 
			case 3:
				_targerTime = 0f; 
				//to be decided
				break; 
		}	
	}
	// Update is called once per frame
	void Update ()
	{
		
		
		SongTime = AudioSource.time;
//		Debug.Log("Songtime is : " +SongTime);

		if (SongTime >= _targerTime)
		{
				_go = Instantiate(Indicator, new Vector2(-1f, Player.transform.position.y + 20),transform.rotation);
			if (!DebugMode)
			{
				_go.GetComponentInChildren<SpriteRenderer>().enabled = false; 
			}

			switch (level)
			{
					case 1:
						_targerTime += 0.2255639098f; 
						//_targerTime += 0.45112781954887218f;
						break;
					case 2:
						_targerTime += 0.1694915254f;
						break; 
					case 3:
						_targerTime += 0.1515151515151515151515f;
						//to be decided
						break; 
			}
				//_targerTime += 0.33898305084745763f;
		}	
//		FindClosestEnemy().transform.position = new Vector3(FindClosestEnemy().transform.position.x,
	//		_go.transform.position.y, -10f);
		//_targerTime += 0.45112781954887218f; level 1
	}
	
	public GameObject FindClosestEnemy()
	{
		GameObject[] Enemys;
		Enemys = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		
		foreach (GameObject go in Enemys)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance; 
			}
		}
		return closest; 
	}
}
