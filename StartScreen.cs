using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public Button GameStartBtn;
    public GameObject PlayerIdle;
    public GameObject PlayerMoving; 
    public bool GameStarting;
    public bool AnimationChanged; 
    private float _timer; 
    // Start is called before the first frame update
    void Start()
    {
        AnimationChanged = false; 
        GameStartBtn.onClick.AddListener(StartGame);
        _timer = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStarting)
        {
            if (AnimationChanged == false)
            {
                GameStartBtn.GetComponentInChildren<Text>().text = ""; 
               Instantiate(PlayerMoving, PlayerIdle.transform.position, transform.rotation); 
                Destroy(PlayerIdle);
                AnimationChanged = true; 
            }
            _timer += Time.deltaTime;   
            if (_timer >= 2f)
            {
                SceneManager.LoadScene("LevelSelector");
            }
        }
    }

    void StartGame()
    {
        GameStarting = true; 
    }
    
}
