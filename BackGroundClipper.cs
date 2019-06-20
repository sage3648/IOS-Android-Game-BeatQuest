using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundClipper : MonoBehaviour
{
    public bool First; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        float difference = playerPos.y - transform.position.y;
        if (difference > 50f && !First)
        {
            Destroy(gameObject);
        }
    }
}
