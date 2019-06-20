using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunRight : MonoBehaviour
{
    private float xValue; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xValue += 1.7f * Time.deltaTime;
        transform.position = new Vector2(xValue, transform.position.y); 
    }
}
