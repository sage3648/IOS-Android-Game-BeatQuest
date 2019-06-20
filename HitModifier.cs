using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitModifier : MonoBehaviour
{

    public float HitTimer;
    public bool Hittable;
    public bool Hit;
    public GameObject Player;
    public GameObject MusicInfront;
    public GameObject HitMarker;
    public GameObject _hitMarkerCreated;
    public GameObject MonsterGrid; 
    public GameObject _hitMarkerCreatedInner; 

    // Use this for initialization
    void Start ()
    {
        MonsterGrid = GameObject.FindGameObjectWithTag("MonsterGrid");
        Player = GameObject.FindWithTag("Player");
        MusicInfront = GameObject.FindWithTag("TopLayerMusic");
        Hittable = true;
        transform.GetComponent<Renderer>().enabled = false; 
    }
	
    // Update is called once per frame
    void Update ()
    {
        //transform.GetComponent<Renderer>().enabled = true; 
        
        if (_hitMarkerCreated != null)
        {
            _hitMarkerCreated.transform.position = new Vector2(transform.position.x,transform.position.y - 0.1f);    
            _hitMarkerCreatedInner.transform.position = new Vector2(transform.position.x,transform.position.y - 0.1f); 
        }

        float differenceFromPlayer;
        differenceFromPlayer = transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y;

        if (differenceFromPlayer <= 20f)
        {
           transform.GetComponent<Renderer>().enabled = true; 
        }
        
        /*if (differenceFromPlayer <= 1f)
        {
            Hittable = true;
        }*/
        
        if (Hittable)
        {
            HitTimer += Time.deltaTime; 
        }	
        
        
        
        //if the enemy passes the player take damage 
        if (transform.position.y < Player.transform.position.y -.5f && tag == "Enemy")
        {
            //Player.GetComponentInChildren<PlayerHealthController>().HealthValue += 2;
            Destroy(gameObject);
            MusicInfront.GetComponentInChildren<AudioSource>().mute = true; 
            Camera.main.GetComponentInChildren<ScoreHandler>().DestroyStreak();
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAnimationController>().Saiyan =
                false; 
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAnimationController>()._animator.SetTrigger("LeaveSaiyan");
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        //Hittable = true; 

       // transform.GetComponentInChildren<SpriteRenderer>().color = Color.cyan;
    }

    private void OnBecameVisible()
    {        
        SnapToTimeLock();
        _hitMarkerCreatedInner = Instantiate(HitMarker,transform.position,transform.rotation);
        _hitMarkerCreatedInner.GetComponentInChildren<HitMarkerBehavior>().InnerCircle = true; 
        _hitMarkerCreated = Instantiate(HitMarker,transform.position,transform.rotation);
        _hitMarkerCreated.GetComponentInChildren<HitMarkerBehavior>().InnerCircle = false; 
       
    }

    private void OnBecameInvisible()
    {
        //Garbage collection
       // if (transform != null transform.position.y <= Player.transform.position.y + 10f);
        //Player.GetComponentInChildren<PlayerHealthController>().HealthValue += 1; 
        // Destroy(gameObject);
    }
    
    
    //Works in collaboration with the TimeLock, to adjust the grid to match the correct spacing and avoid time drift
    void SnapToTimeLock()
    {
        GameObject nearestTimeLock = FindTimingElement();
        float difference = nearestTimeLock.transform.position.y - transform.position.y;
        if (difference < 1f)
        {
            //may need to change for level 1
            transform.SetParent(null);
            MonsterGrid.transform.SetParent(transform);
            transform.position = new Vector3(transform.position.x,nearestTimeLock.transform.position.y,transform.position.z);
            MonsterGrid.transform.SetParent(null);
                
        }

    }
    
    public GameObject FindTimingElement()
    {
        GameObject[] TimeKeepers;
        TimeKeepers = GameObject.FindGameObjectsWithTag("TimeKeeper");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
		
        foreach (GameObject go in TimeKeepers)
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
