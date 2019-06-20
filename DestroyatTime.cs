using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class DestroyatTime : MonoBehaviour
{
    public float Timer;
    public float ToDestroy; 

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= ToDestroy) Destroy(gameObject); 
    }
}
