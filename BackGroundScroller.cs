using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundScroller : MonoBehaviour
{

    public GameObject Player;
    public GameObject Background;
    private float _distanceTravelled;
    private float _gap;
    public bool IsOffset;
    public int Count; 
    
    // Start is called before the first frame update
    void Start()
    {
        Count = 1; 
        GameObject bg = Instantiate(Background, new Vector2(10f, Background.transform.position.y+20f), Background.transform.rotation);
        bg.GetComponentInChildren<BackGroundClipper>().First = false; 
        _gap += 5f; 
    }

    // Update is called once per frame
    void Update()
    {
        _distanceTravelled = +Player.transform.position.y;
        if (_distanceTravelled >= _gap && !IsOffset)
        {
            
            GameObject bg = Instantiate(Background, new Vector3(0f, Player.transform.position.y + 20,0f), Background.transform.rotation);
            bg.GetComponentInChildren<BackGroundClipper>().First = false; 
            _gap += 20f; 
        }
        else if (_distanceTravelled >= _gap)
        {
            _gap += 10f; 
            GameObject bg = Instantiate(Background, new Vector2(10f, Background.transform.position.y + (20f * Count)), Background.transform.rotation);
            bg.GetComponentInChildren<BackGroundClipper>().First = false;
            Count++; 

        }
    }

    /*private void OnBecameInvisible()
    {
        GetComponent<SpriteRenderer>().enabled = false; 
    }

    private void OnBecameVisible()
    {
        GetComponent<SpriteRenderer>().enabled = true; 
    }*/
}
