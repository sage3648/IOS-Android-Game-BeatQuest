using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityScript.Lang;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator _animator;
    public Text HitRatingText;
    public GameObject Blood; 
    private bool _showRatingText; 
    private float _timer;
    public AudioSource MusicInfront;
    public AudioSource HitSlash;
    public AudioSource Miss,Miss2;
    public bool Saiyan;
    public GameObject LineRenderer;
    public GameObject ParticleExplosion; 
    
    // Start is called before the first frame update
    void Start()
    {
        Saiyan = false; 
        _showRatingText = false;
        _animator = GetComponent<Animator>();
        //MusicInfront.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Saiyan)
        {
            _animator.SetTrigger("GoSaiyan");
        }
        HitSlash.pitch = Random.Range(0.7f, 1.3f); 
        HitRatingText.transform.Rotate(Vector3.forward);
        if (_showRatingText)
        {
            _timer += Time.deltaTime;
            if (_timer >= 1.2f)
            {
                _timer = 0f; 
                _showRatingText = false;
                HitRatingText.text = ""; 
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            AttackEvent();
        }
        
        
        
        //Instead calling below in player movement so that it always happens after moving (to calculate enemy proximity)
        
        //Originally Input.GetMouseButtonDown(0), changing to improve Android/IOS experience to touch input    
        /*for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                AttackEvent();
            }           
        }*/
        

    }

    public void AttackEvent()
    {
        GameObject closest = FindClosestEnemy();
            if (closest != null && closest.GetComponentInChildren<HitModifier>().Hittable)
            {
                if (closest.transform.position.y >= transform.position.y + 0.5f)
                {
                    if (Saiyan)
                    {
                        _animator.SetTrigger("SliceUpPurple");
                    }
                    else
                    {
                        _animator.SetTrigger("Slice");
                    }
                    
                    //if(closest.transform.position.x <= transform.position.x + 0.1f && closest.transform.position.y <= transform.position.y + 0.1f);
                    Vector3 diff = closest.transform.position - transform.position;
                    float curDistance = diff.sqrMagnitude;
                    if (curDistance < 2.5f)
                    {
                        Camera.main.GetComponentInChildren<CameraShake>().ShakeDuration = 0.1f; 
                        _showRatingText = true; 
                        
                        //HitRatingText.text = "PERFECT!!!";
                        
                       // gameObject.GetComponentInChildren<PlayerHealthController>().HealthValue -= 1; 
                        
                        //Instantiate(Blood, closest.transform.position,
                          //  Quaternion.Euler(Random.Range(0f, 100f), 0f, 0f));
                        
                       // Instantiate(ParticleExplosion, closest.transform.position, Quaternion.Euler(Vector3.up)); 
                        
                       // Camera.main.GetComponentInChildren<ScoreHandler>().AddStreak(1f);
                       // MusicInfront.mute = false; 
                        //HitSlash.Play();

                       /* if (closest != null)
                        {
                            Destroy(closest.GetComponent<HitModifier>()._hitMarkerCreated);
                            Destroy(closest.GetComponent<HitModifier>()._hitMarkerCreatedInner);
                            Destroy(closest);
                        }*/
                       
                        //LineRenderer.GetComponent<LineAnimator>().HitEvent();
                    }
                    else
                    {
                       /* Camera.main.GetComponentInChildren<ScoreHandler>().DestroyMultiplier();
                        Camera.main.GetComponentInChildren<ScoreHandler>().Streak = 0f; 
                        Camera.main.GetComponentInChildren<ScoreHandler>().DestroyStreak();*/
                        
                    }
                    
                }
                else
                {
                    if (closest.transform.position.y >= transform.position.y - 0.05f)
                    {
                        if (Saiyan)
                        {
                            _animator.SetTrigger("SliceDownPurple");
                        }
                        else
                        {
                            _animator.SetTrigger("SliceBack");
                        }
                        Vector3 diff = closest.transform.position - transform.position;
                        float curDistance = diff.sqrMagnitude;
                        if (curDistance < 2.5f)
                        {
                            
                            Camera.main.GetComponentInChildren<CameraShake>().ShakeDuration = 0.1f; 
                          //  _showRatingText = true; 
                           // HitRatingText.text = "TRASH!!!";
                            
                           // gameObject.GetComponentInChildren<PlayerHealthController>().HealthValue -= 1; 

                            /*Instantiate(ParticleExplosion, closest.transform.position, Quaternion.Euler(Vector3.up)); 
                            
                            Instantiate(Blood, closest.transform.position,*/
                               // Quaternion.Euler(Random.Range(0f, 100f), 0f, 0f));
                            //Camera.main.GetComponentInChildren<ScoreHandler>().AddStreak(1f);
                          //  MusicInfront.mute = false; 
                           // HitSlash.Play();
                            
                            
                            
                            
                           /* if (closest != null)
                            {
                                Destroy(closest.GetComponent<HitModifier>()._hitMarkerCreated);
                                Destroy(closest.GetComponent<HitModifier>()._hitMarkerCreatedInner);
                                Destroy(closest);
                            }*/
                            
                            
                           
                            //LineRenderer.GetComponent<LineAnimator>().HitEvent();
                        }
                        else
                        {
                              /*  Camera.main.GetComponentInChildren<ScoreHandler>().DestroyMultiplier();
                            Camera.main.GetComponentInChildren<ScoreHandler>().Streak = 0f; 
                                Camera.main.GetComponentInChildren<ScoreHandler>().DestroyStreak();*/
                            
                            /*int choice = Random.Range(1, 2);
                            switch (choice)
                            {
                                case 1:
                                    Miss.Play();
                                    break; 
                                case 2:
                                    Miss2.Play();
                                    break;       
                            }*/
                        }
                    }
                    else
                    {
                        if (closest.transform.position.x < transform.position.x)
                        {
                            if (Saiyan)
                            {
                                _animator.SetTrigger("SliceLeftPurple");
                            }
                            else
                            {
                                _animator.SetTrigger("SliceLeft");
                            }
                            Vector3 diff = closest.transform.position - transform.position;
                            float curDistance = diff.sqrMagnitude;
                            if (curDistance < 2.5f)
                            {
                               // Camera.main.GetComponentInChildren<ScoreHandler>().AddStreak(1f);
                                
                               // Instantiate(ParticleExplosion, closest.transform.position, Quaternion.Euler(Vector3.up)); 

                              //  Instantiate(Blood, closest.transform.position,
                                  //  Quaternion.Euler(Random.Range(0f, 100f), 0f, 0f));
                                //MusicInfront.mute = false; 
                                //HitSlash.Play();
                                
                                
                               /* if (closest != null)
                                {
                                    Destroy(closest.GetComponent<HitModifier>()._hitMarkerCreated);
                                    Destroy(closest.GetComponent<HitModifier>()._hitMarkerCreatedInner);
                                    Destroy(closest);
                                }*/
                                
                               
                               // LineRenderer.GetComponent<LineAnimator>()._hit = true;

                            }
                        }
                        if (closest.transform.position.x > transform.position.x)
                        {
                            if (Saiyan)
                            {
                                _animator.SetTrigger("SliceRightPurple");
                            }
                            else
                            {
                                _animator.SetTrigger("SliceRight");
                            }
                            Vector3 diff = closest.transform.position - transform.position;
                            float curDistance = diff.sqrMagnitude;
                            if (curDistance < 2.5)
                            {
                             //   Camera.main.GetComponentInChildren<ScoreHandler>().AddStreak(1f);
                                
                               // Instantiate(ParticleExplosion, closest.transform.position, Quaternion.Euler(Vector3.up)); 
                                
                               /*Instantiate(Blood, closest.transform.position,
                                    Quaternion.Euler(Random.Range(0f, 100f), Random.Range(0f, 100f), 0f));
                                MusicInfront.mute = false; 
                                HitSlash.Play();*/
                                
                                
                                /*if (closest != null)
                                {
                                    Destroy(closest.GetComponent<HitModifier>()._hitMarkerCreated);
                                    Destroy(closest.GetComponent<HitModifier>()._hitMarkerCreatedInner);
                                    Destroy(closest);
                                }*/


                               
                                
                                
                              //  LineRenderer.GetComponent<LineAnimator>().HitEvent();
                            }
                           
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
}
