using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.Win32;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public GameObject HealthBar;
    public Sprite health1,health2,health3,health4,health5,health6,health7,health8,health9,health10,health11,health12,health13;
    public int HealthValue;
    public bool GameOver; 
    public GameObject GameOverTxt;
    private int _levelSelected;
   // public GameObject Background;
    private float _backGroundOpacity; 
    // Start is called before the first frame update
    void Start()
    {
        _levelSelected = Camera.main.GetComponentInChildren<ScoreHandler>().LevelSelected; 
        GameOver = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthValue >= 13)
        {
            LoseEvent();   
        }

        if (GameOver)
        {
           // Background.GetComponentInChildren<Tilemap>().color = Color.black;
            
            if(Input.GetMouseButtonDown(0))
            {
                //reset to the correct level(scene)
                switch (_levelSelected)
                {
                    case 1:
                        SceneManager.LoadScene("SampleScene");
                        break;
                    case 2:
                        SceneManager.LoadScene("Level2");
                        break;     
                } 
                Time.timeScale = 1f; 
            }
        }
        switch (HealthValue)
        {
            case 1:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health1; 
                break; 
            case 2:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health2; 
                break; 
            case 3:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health3; 
                break; 
            case 4:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health4; 
                break; 
            case 5:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health5; 
                break; 
            case 6:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health6; 
                break; 
            case 7:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health7; 
                break; 
            case 8:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health8; 
                break; 
            case 9:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health9; 
                break; 
            case 10:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health10; 
                break; 
            case 11:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health11; 
                break; 
            case 12:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health12; 
                break; 
            case 13:
                HealthBar.GetComponentInChildren<SpriteRenderer>().sprite = health13; 
                break; 
        }
    }

    void SetHealth(int newHealth)
    {
        HealthValue = newHealth; 
    }

    public  void LoseEvent()
    {
        GameOverTxt.GetComponentInChildren<Text>().text = "YOU LOSE TAP TO RESTART";
        GameOver = true;
        //pausing audio in front pauses musicDeltaTime since it is calculated from that source
        //Camera.main.GetComponentInChildren<TorchSpawner>().SongToTrack.Pause();
        GameObject.FindGameObjectWithTag("TopLayerMusic").GetComponentInChildren<AudioSource>().Pause();
        
        Time.timeScale = 0.2f;
        //Time.timeScale = 0f; 
    }
}
