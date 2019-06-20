using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button SelectLevelOneBtn;
    public Button SelectLevelTwoBtn;
    public Text LevelOneTxt;
    private Score _scoreController;

    // Start is called before the first frame update
    void Start()
    {
        SelectLevelOneBtn.onClick.AddListener(SelectLevelOne);
        SelectLevelTwoBtn.onClick.AddListener(SelectLevelTwo); 
        
       // LevelOneTxt.text = "Into the Dungeon"; 

    }

    // Update is called once per frame
    void Update()
    {
    
        LevelOneTxt.text = "Into the Dungeon\n" + PlayerPrefs.GetFloat("Level1");
    }

    void SelectLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    void SelectLevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
    void SelectLevelThree()
    {
        SceneManager.LoadScene("Level3");
        //To be created!
    }
}
