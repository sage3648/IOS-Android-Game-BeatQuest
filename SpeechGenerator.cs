using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class SpeechGenerator : MonoBehaviour
{
    public Text OutputTxt;
    public String Paragraph1;
    public String Paragraph2;
    public String Paragraph3;
    public String Paragraph4;
    public String Paragraph5;
    public String Paragraph6;
    public String Paragraph7;
    public String Paragraph10; 
    public String Paragraph11; 
    public String Paragraph12; 
    public String ParagraphFail;
    public AudioSource TypingSound;
    public AudioSource TypingSound2; 
    public AudioSource TypingSound3;
    public AudioSource TypingSound4;
    public AudioSource Note; 
    public bool RandomSound; 
    private float _timer;
    private char[] _para1; 
    private char[] _para2;
    private char[] _para3;
    private char[] _para4; 
    private char[] _para5; 
    private char[] _para6;
    private char[] _para7;
    private char[] _para10; 
    private char[] _para11; 
    private char[] _para12; 

    private char[] _paraFail; 
    private int _counter;
    private float _targetTimer;
    private int _currentParagraph;
    public ParticleSystem Particles;
    public AudioSource Music;
    public AudioSource Note2; 
    public GameObject TutorialEnemy;
    public Material Red;
    private bool _canFail;
    public Canvas dCanvas; 
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Music.Play();
        _currentParagraph = 1; 
        _targetTimer = 0.03f; 
        OutputTxt.text = "";
        _canFail = false; 
        
        _para1 = new char[Paragraph1.Length];
        _para2 = new char[Paragraph2.Length];
        _para3 = new char[Paragraph3.Length];
        _para4 = new char[Paragraph4.Length];
        _para5 = new char[Paragraph5.Length];
        _para6 = new char[Paragraph6.Length];
        _para7 = new char[Paragraph7.Length];
        _para10 = new char[Paragraph10.Length];
        _para11 = new char[Paragraph11.Length];
        _para12 = new char[Paragraph12.Length];
        _paraFail = new char[ParagraphFail.Length];


        _counter = 0; 
        foreach (char c in Paragraph1)
        {
            
            _para1[_counter] = c;
            //Debug.Log(_para1[_counter]);
            _counter++;
        }
        _counter = 0; 
        
        foreach (char c in Paragraph2)
        {
            _para2[_counter] = c;
           // Debug.Log(_para2[_counter]);
            _counter++;
        }
        _counter = 0; 
        
        foreach (char c in Paragraph3)
        {
            _para3[_counter] = c;
            // Debug.Log(_para2[_counter]);
            _counter++;
        }
        _counter = 0; 
        
        foreach (char c in Paragraph4)
        {
            _para4[_counter] = c;
            // Debug.Log(_para2[_counter]);
            _counter++;
        }
        _counter = 0; 
        
        foreach (char c in Paragraph5)
        {
            _para5[_counter] = c;
            // Debug.Log(_para2[_counter]);
            _counter++;
        }
        _counter = 0; 
        
        foreach (char c in Paragraph6)
        {
            _para6[_counter] = c;
            // Debug.Log(_para2[_counter]);
            _counter++;
        }
        _counter = 0; 
        
        foreach (char c in Paragraph7)
        {
            _para7[_counter] = c;
            // Debug.Log(_para2[_counter]);
            _counter++;
        }
        _counter = 0; 
        
        foreach (char c in ParagraphFail)
        {
            _paraFail[_counter] = c;
            // Debug.Log(_para2[_counter]);
            _counter++;
        }
        _counter = 0; 
        
        foreach (char c in Paragraph10)
        {
            _para10[_counter] = c;
            // Debug.Log(_para2[_counter]);
            _counter++;
        }
        _counter = 0; 
        
        foreach (char c in Paragraph11)
        {
            _para11[_counter] = c;
            // Debug.Log(_para2[_counter]);
            _counter++;
        }
        _counter = 0; 
        
        foreach (char c in Paragraph12)
        {
            _para12[_counter] = c;
            // Debug.Log(_para2[_counter]);
            _counter++;
        }
        _counter = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentParagraph == 8)
        {
            if (TutorialEnemy != null)
            {
                TutorialEnemy.transform.position = new Vector2(TutorialEnemy.transform.position.x,TutorialEnemy.transform.position.y - 1.5f * Time.deltaTime);
            }
            if (TutorialEnemy != null && _canFail == true && TutorialEnemy.transform.position.y <
                GameObject.FindGameObjectWithTag("Player").transform.position.y)
            {
                Instantiate(Particles, GameObject.FindGameObjectWithTag("Player").transform.position, transform.rotation);
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Renderer>().enabled = false; 
                Music.Stop();
                //Debug.Log("YOu FuckEd Up!");
                _counter = 0;
                _timer = 1f;
                _targetTimer = 1; 
                _currentParagraph = 69; 
                // SceneManager.LoadScene("Level1");
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            //_currentParagraph = 10; 

            //_timer = 50f;
            if (_currentParagraph == 4)
            {
                Note.Play();
                Instantiate(Particles, GameObject.FindGameObjectWithTag("Player").transform.position,
                    transform.rotation);
               // GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetBool("Idle",false);
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetTrigger("Slice");
               // GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetBool("Idle",true);

                _targetTimer = 1f;
                _timer = 1f; 
                _currentParagraph = 5; 
            }

            if (_currentParagraph == 8)
            {
                //for debugging

                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAnimationController>().AttackEvent();

                if (TutorialEnemy == null)
                {
                    Note2.Play();
                    _targetTimer = 1f;
                    _timer = 1f; 
                    _currentParagraph = 10; 
                }
                //GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetBool("Idle",false);
                //GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetBool("Idle",true);
               /* if (TutorialEnemy.transform.position.y > GameObject.FindGameObjectWithTag("Player").transform.position.y)
                {
                   
                }*/
              
            }
        }
        _timer += Time.deltaTime;
        if (_timer >= _targetTimer)
        {
            if (_targetTimer >= 1f) OutputTxt.text = ""; 
            switch (_currentParagraph)
            {
                    case 1:
                        TypeParagraph1();
                        break;
                    case 2:
                        _targetTimer = 0.03f; 
                        TypeParagraph2();
                        break;
                    case 3:
                        _targetTimer = 0.03f; 
                        TypeParagraph3();
                        break; 
                    case 4:
                        _targetTimer = 0.03f; 
                        TypeParagraph4();
                        break; 
                     case 5:
                         _targetTimer = 0.03f; 
                          TypeParagraph5();
                          break; 
                     case 6:
                        _targetTimer = 0.03f; 
                         TypeParagraph6();
                          break; 
                    case 7:
                         _targetTimer = 0.03f; 
                         TypeParagraph7();
                         break; 
                    case 10:
                        _targetTimer = 0.5f; 
                        TypeParagraph10();
                        break; 
                    case 11:
                        _targetTimer = 0.1f; 
                        TypeParagraph11();
                        break; 
                    case 12:
                         _targetTimer = 0.03f; 
                         TypeParagraph12();
                         break; 
                    case 20:
                        dCanvas.enabled = false;
                    
                    break; 
                     case 69:
                        _targetTimer = 0.06f; 
                        TypeFailureParagraph();
                         break; 
            }
         // TypeParagraph1();    
            //TypingSound.Stop();
        }
        
    }

    void PlayTypingSound()
    {
        if (RandomSound)
        {
            int choice = UnityEngine.Random.Range(1, 4);
            switch (choice)
            {
                case 1:
                    TypingSound.Play();
                    break;
                case 2:
                    TypingSound2.Play();
                    break; 
                case 3:
                    TypingSound3.Play();
                    break; 
                case 4:
                    TypingSound4.Play();
                    break; 
            }   
        }
        else
        {
            TypingSound.Play(); 
        }
    }
    
    void TypeParagraph1()
    {
        OutputTxt.text = OutputTxt.text + _para1[_counter]; 
        PlayTypingSound();
        _counter++;
        _timer = 0f;
        if (_counter >= _para1.Length)
        {
            _currentParagraph = 2; 
            _targetTimer = 1f;
            _counter = 0; 
            
        } 
    }
    
    void TypeParagraph2()
    {
       // Debug.Log(_counter);
        OutputTxt.text = OutputTxt.text + _para2[_counter]; 
        PlayTypingSound();
        _counter++;
        _timer = 0f;
        if (_counter >= _para2.Length)
        {
            _currentParagraph = 3; 
            _targetTimer = 1.5f;
            _counter = 0;
            _timer = 0f; 
        }
    }
    
    void TypeParagraph3()
    {
        //Debug.Log(_counter);
        OutputTxt.text = OutputTxt.text + _para3[_counter]; 
        PlayTypingSound();
        _counter++;
        _timer = 0f;
        if (_counter >= _para3.Length)
        {
            _currentParagraph = 4; 
            _targetTimer = 1.5f;
            _counter = 0;
            _timer = 0f; 
        }
    }
    
    void TypeParagraph4()
    {
        //Debug.Log(_counter);
        OutputTxt.text = OutputTxt.text + _para4[_counter]; 
        PlayTypingSound();
        _counter++;
        _timer = 0f;
        if (_counter >= _para4.Length)
        {
            _currentParagraph = 4; 
            _targetTimer = 1000f;
            _counter = 0;
            _timer = 0f; 
        }
    }
    
    void TypeParagraph5()
    {
        //Debug.Log(_counter);
        OutputTxt.text = OutputTxt.text + _para5[_counter]; 
        PlayTypingSound();
        _counter++;
        _timer = 0f;
        if (_counter >= _para5.Length)
        {
            _currentParagraph = 6; 
            _targetTimer = 1.5f;
            _counter = 0;
            _timer = 0f; 
        }
    }
    void TypeParagraph6()
    {
        //Debug.Log(_counter);
        OutputTxt.text = OutputTxt.text + _para6[_counter]; 
        PlayTypingSound();
        _counter++;
        _timer = 0f;
        if (_counter >= _para6.Length)
        {
            TutorialEnemy = Instantiate(TutorialEnemy, new Vector3(0, 1.5f, 0f), transform.rotation);
            Particles.startSpeed = 150;
            Particles.maxParticles = 50;
            Particles.GetComponentInChildren<Renderer>().material = Red; 
            Instantiate(Particles, TutorialEnemy.transform.position, transform.rotation);
            _currentParagraph = 7; 
            _targetTimer = 1f;
            _counter = 0;
            _timer = 0f; 
        }
    }
    void TypeParagraph7()
    {
        Debug.Log(_counter);
        OutputTxt.text = OutputTxt.text + _para7[_counter]; 
        PlayTypingSound();
        _counter++;
        _timer = 0f;
        if (_counter >= _para7.Length)
        {
            _canFail = true;
            _currentParagraph = 8; 
            _targetTimer = 50f;
            _counter = 0;
            _timer = 0f; 
        }
    }

    void TypeParagraph10()
    {
        Debug.Log("You made it to para 10");
        OutputTxt.text = OutputTxt.text + _para10[_counter]; 
        PlayTypingSound();
        _counter++;
        _timer = 0f;
        if (_counter >= _para10.Length)
        {
            _currentParagraph = 11; 
            _targetTimer = 1f;
            _counter = 0;
            _timer = 0f; 
        }
    }
    
    void TypeParagraph11()
    {
        OutputTxt.text = OutputTxt.text + _para11[_counter]; 
        PlayTypingSound();
        _counter++;
        _timer = 0f;
        if (_counter >= _para11.Length)
        {
            _currentParagraph = 12; 
            _targetTimer = 1f;
            _counter = 0;
            _timer = 0f; 
        }
    }
    
    void TypeParagraph12()
    {
        OutputTxt.text = OutputTxt.text + _para12[_counter]; 
        PlayTypingSound();
        _counter++;
        _timer = 0f;
        if (_counter >= _para12.Length)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetBool("Idle",false);
           Camera.main.GetComponentInChildren<PauseHandler>().ResumeGameNoMenu();
           Music.Stop();
            _currentParagraph = 20; 
            _targetTimer = 1f;
            _counter = 0;
            _timer = 0f; 
        }
        
    }

    void TypeFailureParagraph()
    {
        OutputTxt.fontSize = 150; 
        //Debug.Log(_counter);
        OutputTxt.text = OutputTxt.text + _paraFail[_counter]; 
        PlayTypingSound();
        _counter++;
        _timer = 0f;
        if (_counter >= _paraFail.Length)
        {
            SceneManager.LoadScene("Level1"); 
        }
    }
}
