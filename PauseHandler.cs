using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour
{
    public Button RestartBtn;
    public Button LevelSelectBtn;
    public Button ResumeBtn;
    public Button PauseBtn; 
    public GameObject PauseGameMenu;
    private Vector3 _originalPosition;
    public AudioSource MusicInfront;
    public AudioSource MusicBehind;
    public Text CountDownTxt;
    private float _counter;
    private bool _counting; 
    
    
    void Start()
    {
        _counter = 4f; 
        PauseGameMenu.SetActive(false);
        
        //_originalPosition = PauseGameMenu.transform.position; 
        //PauseGameMenu.transform.position = new Vector3(-100f,0f,0f);
        LevelSelectBtn.onClick.AddListener(LevelSelector);
        ResumeBtn.onClick.AddListener(ResumeGame);
        PauseBtn.onClick.AddListener(PauseGame);
        RestartBtn.onClick.AddListener(RestartGame);
    }

    public void PauseGame()
    {
        PauseGameMenu.SetActive(true);
        MusicInfront.Pause();
        MusicBehind.Pause();
        Time.timeScale = 0;
        //PauseGameMenu.transform.position = _originalPosition; 
    }

    public void PauseGameNoMenu()
    {
        MusicInfront.Pause();
        MusicBehind.Pause();
        //Time.timeScale = 0;
    }

    public void ResumeGameNoMenu()
    {
        MusicInfront.Play();
        MusicBehind.Play();
    }
    private void FixedUpdate()
    {
        if (_counting)
        {
            CountDownTxt.text =" " + (int) _counter;
            _counter -= Time.deltaTime;
            if (_counter <= .9f)
            {
                _counting = false; 
                MusicInfront.UnPause();
                MusicBehind.UnPause();
            }
        }
        else
        {
            CountDownTxt.text = ""; 
            _counter = 4f; 
        }
    }

    public void ResumeGame()
    {
 
        PauseGameMenu.SetActive(false);
        Time.timeScale = 1;
        _counting = true; 
     
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        //Use in other parts instead of switchs for saving scores etc? 
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void LevelSelector()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelector");
    }
}
