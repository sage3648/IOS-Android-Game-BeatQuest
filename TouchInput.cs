using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    private Animator _animator;
    public Text HitRatingText;
    public AudioSource MusicInfront;
    public AudioSource HitSlash;
    public AudioSource Miss,Miss2;
    public GameObject ParticleExplosion;
    public GameObject LineRenderer;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        NotePress();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            KeyNotePress(Input.mousePosition);
            
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            KeyNotePress(Input.mousePosition);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            KeyPressHold();
        }
        if (Input.GetKey(KeyCode.X))
        {
            KeyPressHold(); 
        }
        
    }


    void KeyPressHold()
    {

      Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            

            GameObject Test = NearestUpperNote();
            if (Test != null)
            {
                Vector3 diff = Test.transform.position - gameObject.transform.position;
                float curDistance = diff.sqrMagnitude;

                if (curDistance < 1f && Test != null && NearestUpperNote().GetComponentInChildren<NodeConnector>().start_of_note)
                {
                    gameObject.GetComponentInChildren<PlayerAnimationController>()._animator.SetTrigger("Slice");
                    transform.position = new Vector2(hit.point.x,transform.position.y);
                    Test.GetComponentInChildren<NodeConnector>().BeingHit = true; 
                    Instantiate(ParticleExplosion, Test.transform.position, Quaternion.Euler(Vector3.up));
                }
                else
                {
                    Test.GetComponentInChildren<NodeConnector>().BeingHit = false; 
                }

            }
            
           
        }
        
    }
    
    void KeyNotePress(Vector3 mouse)
    {
        
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
             Vector3 touchLocation = hit.point; 
                    touchLocation.y = GameObject.FindGameObjectWithTag("Player").transform.position.y; 
                    GameObject closestEnemy = FindClosestEnemy();
                    if (closestEnemy != null)
                    {
                         float differenceX = touchLocation.x - closestEnemy.transform.position.x;
                    float differenceY = touchLocation.y - closestEnemy.transform.position.y;
                    
                    
                    Vector3 diff = closestEnemy.transform.position - touchLocation;
                    float curDistance = diff.sqrMagnitude;

                    //if close to not (within 1.5)
                    if (curDistance < 2f && closestEnemy != null)
                    {
                        
                        MusicInfront.mute = false; 
                        HitSlash.Play();
                        Camera.main.GetComponentInChildren<ScoreHandler>().AddStreak(1f);
                        Instantiate(ParticleExplosion, closestEnemy.transform.position, Quaternion.Euler(Vector3.up)); 
                        LineRenderer.GetComponent<LineAnimator>().HitEvent();

                        
                        int playerHealth =  gameObject.GetComponentInChildren<PlayerHealthController>().HealthValue;
                        if (playerHealth > 0)
                        {
                            gameObject.GetComponentInChildren<PlayerHealthController>().HealthValue -= 1;
                        }
                        
                        //perfect hit range
                        if (curDistance < 1f)
                        {
                            HitRatingText.text = "PERFECT";
                        }
                        else
                        {
                            {
                                //if note is in front, early
                                if (closestEnemy.transform.position.y > touchLocation.y)
                                {
                                    HitRatingText.text = "EARLY";

                                }
                                //if note is behind, late 
                                if (closestEnemy.transform.position.y < touchLocation.y)
                                {
                                    HitRatingText.text = "LATE";
                                }
                            }
                        }
                        Destroy(closestEnemy.GetComponent<HitModifier>()._hitMarkerCreated);
                        Destroy(closestEnemy.GetComponent<HitModifier>()._hitMarkerCreatedInner);
                        Destroy(closestEnemy);
                       
                    }
                    else
                    {
                        int choice = Random.Range(1, 2);
                        switch (choice)
                        {
                            case 1:
                                Miss.Play();
                                break; 
                            case 2:
                                Miss2.Play();
                                break;       
                        }
                        Camera.main.GetComponentInChildren<ScoreHandler>().DestroyMultiplier();
                        Camera.main.GetComponentInChildren<ScoreHandler>().Streak = 0f; 
                        Camera.main.GetComponentInChildren<ScoreHandler>().DestroyStreak();
                    }
                    }
                   
                
        }
    }

    void NotePress()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Vector3 touchLocation = hit.point; 
                    touchLocation.y = GameObject.FindGameObjectWithTag("Player").transform.position.y; 
                    GameObject closestEnemy = FindClosestEnemy(); 
                    float differenceX = touchLocation.x - closestEnemy.transform.position.x;
                    float differenceY = touchLocation.y - closestEnemy.transform.position.y;
                    
                    
                    Vector3 diff = closestEnemy.transform.position - touchLocation;
                    float curDistance = diff.sqrMagnitude;

                    //if close to not (within 1.5)
                    if (curDistance < 2f && closestEnemy != null)
                    {
                        
                        MusicInfront.mute = false; 
                        HitSlash.Play();
                        Camera.main.GetComponentInChildren<ScoreHandler>().AddStreak(1f);
                        Instantiate(ParticleExplosion, closestEnemy.transform.position, Quaternion.Euler(Vector3.up)); 
                        LineRenderer.GetComponent<LineAnimator>().HitEvent();

                        
                        int playerHealth =  gameObject.GetComponentInChildren<PlayerHealthController>().HealthValue;
                        if (playerHealth > 0)
                        {
                            gameObject.GetComponentInChildren<PlayerHealthController>().HealthValue -= 1;
                        }
                        
                        //perfect hit range
                        if (curDistance < 0.5)
                        {
                            HitRatingText.text = "PERFECT";
                        }
                        else
                        {
                            {
                                //if note is in front, early
                                if (closestEnemy.transform.position.y > touchLocation.y)
                                {
                                    HitRatingText.text = "EARLY";

                                }
                                //if note is behind, late 
                                if (closestEnemy.transform.position.y < touchLocation.y)
                                {
                                    HitRatingText.text = "LATE";
                                }
                            }
                        }
                        Destroy(closestEnemy.GetComponent<HitModifier>()._hitMarkerCreated);
                        Destroy(closestEnemy.GetComponent<HitModifier>()._hitMarkerCreatedInner);
                        Destroy(closestEnemy);
                       
                    }
                    else
                    {
                        int choice = Random.Range(1, 2);
                        switch (choice)
                        {
                            case 1:
                                Miss.Play();
                                break; 
                            case 2:
                                Miss2.Play();
                                break;       
                        }
                        Camera.main.GetComponentInChildren<ScoreHandler>().DestroyMultiplier();
                        Camera.main.GetComponentInChildren<ScoreHandler>().Streak = 0f; 
                        Camera.main.GetComponentInChildren<ScoreHandler>().DestroyStreak();
                    }
                }
            }
        }

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
    public GameObject FindLongPress()
    {
        GameObject[] Enemys;
        Enemys = GameObject.FindGameObjectsWithTag("LongPress");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
		
        foreach (GameObject go in Enemys)
        {
            if (go.GetComponentInChildren<LongPressNote>().start_of_note)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance; 
                }
            }
           
        }
        return closest;
    }
    GameObject NearestUpperNote()
    {
        GameObject[] AllLongNotes = GameObject.FindGameObjectsWithTag("LongPress");

        GameObject closest = null;
        float distance = Mathf.Infinity;
        foreach (GameObject go in AllLongNotes)
        {

            Vector3 position = gameObject.transform.position;

            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && go.transform.position.y > gameObject.transform.position.y)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
