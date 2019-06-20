using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBehavior : MonoBehaviour
{

    public float SelfDestructTimer; 
    // Start is called before the first frame update
    void Start()
    {
        SelfDestructTimer = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        SelfDestructTimer += Time.deltaTime;
        transform.position = new Vector2(transform.position.x, GameObject.FindWithTag("Player").transform.position.y);
        if (SelfDestructTimer >= 0.2f)
        {
            Destroy(gameObject);
        }

    }
}
