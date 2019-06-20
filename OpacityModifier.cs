using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpacityModifier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, .3f); 
    }
}
