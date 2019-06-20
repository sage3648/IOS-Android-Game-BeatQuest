using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using DefaultNamespace;
using SpriteGlow;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public float Score;
    public float Multiplier;
    public float Streak;
    public Text MultiplierText;
    public Text StreakText;
    public Text ScoreText;
    public float HighestStreak; 
    public bool GameEnding;
    public Canvas LevelCompleteCanvas;
    public Text EndGameScoreTxt, EndGameStreakTxt;
    public Button NextLevelBtn;
    public GameObject TimesEightStreak;
    public GameObject TimesTwoStreak; 
    private GameObject InGameVisual; 
    public bool CreatedMultipler;
    //private Score _ScoreController;
    public GameObject BackGroundEffect1;
    private float _timer;
    private float _interval;
    public int LevelSelected;

    public Material GlowMaterialMonster;
    public Material GlowMaterialUI;
    public Material TMultiplerMaterial;
    public Material FMultiplirtMaterial; 
    public Material EMultiplirtMaterial; 
    public Material DefaultMat;

    public ParticleSystem GameParticleSystem; 
    // Start is called before the first frame update
    void Start()
    {
        CreatedMultipler = false; 
        NextLevelBtn.onClick.AddListener(NextLevel);
        GameEnding = false;
        BackGroundEffect1.GetComponent<Renderer>().enabled = false;
        _interval = 0.9022556391f;
    }

    // Update is called once per frame
    void Update()
    {
        //Streak += 50; 
       // Streak = 50; 
        
       // Streak = 50; 
        
        if(!CreatedMultipler)
        {
            InGameVisual = Instantiate(TimesEightStreak,
                GameObject.FindGameObjectWithTag("Player").transform.position, transform.rotation);
            CreatedMultipler = true; 
        } 
        //InGameVisual.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position; 
       // InGameVisual.GetComponent<Renderer>().enabled = true; 
        
        _timer += GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>().MusicDeltaTime;
//        Debug.Log("Timer is " + _timer);
 //       Debug.Log("Interval is " + _interval);
        if (_timer >= _interval)
        {
            BackGroundEffect1.GetComponent<Animator>().SetTrigger("Beat");
            _interval+=  0.9022556391f;
            
        }
        MultiplierText.text = "x" + Multiplier;
        StreakText.text = "" + Streak;
        ScoreText.text = "" + Score; 
        AddMultiplier();
        if (GameEnding) EndGame(); 
        
    }

    public void SetScore(float newScore)
    {
        Score = newScore;
    }

    public void AddMultiplier()
    {
        if (Streak >= 10f && Streak < 30f)
        {

            
            GameObject[] ui = GameObject.FindGameObjectsWithTag("UI");
            foreach (GameObject go in ui)
            {
                go.GetComponentInChildren<Text>().material = TMultiplerMaterial; 
            }
       
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject go in Monsters)
            {
               go.GetComponentInChildren<SpriteGlowEffect>().GlowColor = Color.green;
               go.GetComponentInChildren<SpriteGlowEffect>().GlowBrightness = 2.5f; 
            }
            
            GameObject Player = GameObject.FindWithTag("Player");
            Player.GetComponentInChildren<SpriteGlowEffect>().GlowColor = Color.green;
            Player.GetComponentInChildren<SpriteGlowEffect>().GlowBrightness = 2.5f; 
            
            GameObject lineRender = GameObject.FindGameObjectWithTag("LineRender");

            lineRender.GetComponentInChildren<LineAnimator>().lr.material = TMultiplerMaterial;
            
            
            GameParticleSystem.GetComponent<Renderer>().material = TMultiplerMaterial; 
            GameParticleSystem.startSpeed = 225;
            GameParticleSystem.maxParticles = 30; 

            
            
            
           // TMultiplerMaterial; 
            MultiplierText.color = new Color(0.1f,0.8f,0.3f);
            ScoreText.color = new Color(0.1f,0.8f,0.3f);
            Multiplier = 2f;
            BackGroundEffect1.GetComponent<Renderer>().enabled = true; 
            BackGroundEffect1.GetComponent<SpriteRenderer>().color = new Color(0.3f,0.8f,0.1f);
            
            
           
        }

        if (Streak >= 30f && Streak < 50f)
        {
            
            GameObject[] ui = GameObject.FindGameObjectsWithTag("UI");
            foreach (GameObject go in ui)
            {
                go.GetComponentInChildren<Text>().material = FMultiplirtMaterial; 
            }
       
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject go in Monsters)
            {
                go.GetComponentInChildren<SpriteGlowEffect>().GlowColor = Color.red;
                go.GetComponentInChildren<SpriteGlowEffect>().GlowBrightness = 3.5f; 
            }
            
            GameObject Player = GameObject.FindWithTag("Player");
            Player.GetComponentInChildren<SpriteGlowEffect>().GlowColor = Color.red;
            Player.GetComponentInChildren<SpriteGlowEffect>().GlowBrightness = 3.5f; 
            
            GameObject lineRender = GameObject.FindGameObjectWithTag("LineRender");

            lineRender.GetComponentInChildren<LineAnimator>().lr.material = FMultiplirtMaterial;
            
            
            GameParticleSystem.GetComponent<Renderer>().material = FMultiplirtMaterial; 
            GameParticleSystem.startSpeed = 260;
            GameParticleSystem.maxParticles = 40; 
            
            
            
            MultiplierText.color = new Color(0.8f,0.5f,0.1f); 
            ScoreText.color = new Color(0.8f,0.5f,0.1f); 
            Multiplier = 4f;
            BackGroundEffect1.GetComponent<SpriteRenderer>().color = new Color(0.9f,0.4f,0.1f);
            if (Streak >= HighestStreak) HighestStreak = Streak; 
        }

        if (Streak >= 50f)
        {
            
   
            
            
            GameObject[] ui = GameObject.FindGameObjectsWithTag("UI");
            foreach (GameObject go in ui)
            {
                go.GetComponentInChildren<Text>().material = EMultiplirtMaterial; 
            }
       
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject go in Monsters)
            {
                go.GetComponentInChildren<SpriteGlowEffect>().GlowColor = new Color(0.8f,0.2f,0.8f);
                go.GetComponentInChildren<SpriteGlowEffect>().GlowBrightness = 5f; 
            }
            
            GameObject Player = GameObject.FindWithTag("Player");
            Player.GetComponentInChildren<SpriteGlowEffect>().GlowColor = new Color(0.8f,0.2f,0.8f);
            Player.GetComponentInChildren<SpriteGlowEffect>().GlowBrightness = 5f; 
            
            GameObject lineRender = GameObject.FindGameObjectWithTag("LineRender");

            lineRender.GetComponentInChildren<LineAnimator>().lr.material = EMultiplirtMaterial;
            
            
            GameParticleSystem.GetComponent<Renderer>().material = EMultiplirtMaterial; 
            GameParticleSystem.startSpeed = 500;
            GameParticleSystem.maxParticles = 50; 
            
            
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAnimationController>().Saiyan =
                true; 
            Multiplier = 8f;
            BackGroundEffect1.GetComponent<SpriteRenderer>().color = new Color(0.7f,0.2f,0.6f);
            if(!CreatedMultipler)
            {
               InGameVisual = Instantiate(TimesEightStreak,
                GameObject.FindGameObjectWithTag("Player").transform.position, transform.rotation);
                CreatedMultipler = true; 
            } 
            InGameVisual.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position; 
            InGameVisual.GetComponent<Renderer>().enabled = true; 
        }
        
        if(Streak <= 0f)
        {
            MultiplierText.color = Color.white; 
            ScoreText.color = Color.white;
            Multiplier = 0f;

            GameParticleSystem.startSpeed = 200;
            GameParticleSystem.maxParticles = 25; 
            GameParticleSystem.GetComponent<Renderer>().material = DefaultMat; 
            
            GameObject[] ui = GameObject.FindGameObjectsWithTag("UI");
            foreach (GameObject go in ui)
            {
                go.GetComponentInChildren<Text>().material = DefaultMat; 
            }
       
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject go in Monsters)
            {
                go.GetComponentInChildren<SpriteGlowEffect>().GlowColor = Color.grey;
                go.GetComponentInChildren<SpriteGlowEffect>().GlowBrightness = 2.5f; 
            }
            
            GameObject Player = GameObject.FindWithTag("Player");
            Player.GetComponentInChildren<SpriteGlowEffect>().GlowColor = Color.grey;
            Player.GetComponentInChildren<SpriteGlowEffect>().GlowBrightness = 1f; 
            
            GameObject lineRender = GameObject.FindGameObjectWithTag("LineRender");

            lineRender.GetComponentInChildren<LineAnimator>().lr.material = DefaultMat;
        }
    }

    public void AddStreak(float increaseBy)
    {
        
        ScoreText.GetComponentInChildren<Animator>().SetTrigger("Beat");
        Streak += increaseBy;
        if (Multiplier > 1)
        {
            Score += 100 * Multiplier;
        }
        else
        {
            Score += 100; 
        }
    }
    

    public void DestroyMultiplier()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAnimationController>().Saiyan =
            false; 
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAnimationController>()._animator.SetTrigger("LeaveSaiyan");
        Multiplier = 0f;
        Streak = 0f; 
        CreatedMultipler = false;
        InGameVisual.GetComponent<Renderer>().enabled = false; 
    }

    public void DestroyStreak()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerAnimationController>()._animator.SetTrigger("LeaveSaiyan");

        BackGroundEffect1.GetComponent<Renderer>().enabled = false;
        Streak = 0f; 
//        InGameVisual.GetComponent<Renderer>().enabled = false; 
    }

    public void EndGame()
    {
        LevelCompleteCanvas.sortingOrder = (9);
        EndGameScoreTxt.text = "Score " + Score;
        EndGameStreakTxt.text = "Highest Streak " + HighestStreak; 
        //_ScoreController.SetLevelScore(Score,"Level1");
        
        //Only save score to correct PlayerPref, related to level, adjust in inspector
        switch (LevelSelected)
        {
                case 1:
                    PlayerPrefs.SetFloat("Level1",Score);
                    break;
                case 2: 
                    PlayerPrefs.SetFloat("Level2",Score);
                    break;            
        }
        
    }
    public void NextLevel()
    {
        if(GameEnding)SceneManager.LoadScene("LevelSelector"); 
    }

    public int GetMultiplier()
    {
        int multiplier = 0; 
        if (Streak <= 0)
        {
            multiplier = 0; 
        }

        if (Streak >= 10f && Streak < 30f)
        {
            multiplier = 2; 
        }

        if (Streak >= 30f && Streak < 50f)
        {
            multiplier = 4; 
        }
        if (Streak >= 50f)
        {
            multiplier = 8;
        }
        return multiplier; 
    } 
}
