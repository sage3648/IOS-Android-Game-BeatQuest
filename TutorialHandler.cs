using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetBool("Idle",true);
        Camera.main.GetComponentInChildren<PauseHandler>().PauseGameNoMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
