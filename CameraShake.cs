using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float ShakeAmount;
    public float ShakeDuration; 

    // Start is called before the first frame update
    void Start()
    {
       // ShakeDuration = 0;
        ShakeAmount = Random.Range(0.05f, 0.1f); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 originalPos = Camera.main.transform.position;
        originalPos.x = 0;
        if (ShakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * ShakeAmount;
            ShakeDuration = ShakeDuration - Time.deltaTime; 
        }
        else
        {
            transform.position = originalPos; 
        }
        
    }
}
