using System.Collections;
using System.Collections.Generic;
using SpriteGlow;
using UnityEngine;

public class StayWithPlayer : MonoBehaviour
{
    private GameObject Player;
    private float Colour;
    private float Timer;

    public bool Marker; 
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        Colour = 0.8f; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!Marker)
        {
            float difference;
            difference = transform.position.x - Player.transform.position.x; 
            Timer += Time.deltaTime;
            
            if (Player.transform.position.x > transform.position.x)
            {
                if (difference > 0.15f)
                {
                    Destroy(gameObject);
                }
                Colour -= Timer / 10 - (difference / 10 );
            }
            else
            {
                if (difference < 0.15f)
                {
                    Destroy(gameObject);
                }
                Colour -= Timer / 10 + (difference / 10 );

            }
        
            if (Colour <= 0f)
            {
                Colour = 0; 
            }
//            Debug.Log(Colour);
            transform.GetComponent<SpriteRenderer>().color = new Color(1,1,1,Colour);
            transform.position = new Vector3(transform.position.x,Player.transform.position.y,transform.position.z);
            transform.GetComponentInChildren<SpriteGlowEffect>().GlowColor = new Color( Player.GetComponentInChildren<SpriteGlowEffect>().GlowColor.r,Player.GetComponentInChildren<SpriteGlowEffect>().GlowColor.g,Player.GetComponentInChildren<SpriteGlowEffect>().GlowColor.b,Colour);
            transform.GetComponentInChildren<SpriteGlowEffect>().GlowBrightness =
                Player.GetComponentInChildren<SpriteGlowEffect>().GlowBrightness - 0.3f; 
        }
        if (Timer >= 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
