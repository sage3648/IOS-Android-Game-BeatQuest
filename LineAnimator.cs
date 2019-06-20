using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using Random = System.Random;

public class LineAnimator : MonoBehaviour
{
    private float _positionY;
    private float _positionX;
    private float _pieBoi;
    private float _timer;
    private float _pause; 
    private float _previousSinceLastHit; 
    private int _hitCounter; 
    public LineRenderer lr;
    public bool _hit;
    private int _choice;
    private int _multiplier;

    public Material LRmaterial; 
   // public Material _Material; 


    //public Material Material;

    // Start is called before the first frame update
    void Start()
    {
        _choice = 1;
        _pause = 0.5f; 
        _hit = false; 
        _timer = 0f;
        lr = gameObject.GetComponentInChildren<LineRenderer>();
        lr.startColor = Color.white;
       // lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        transform.GetComponent<LineRenderer>().startColor = new Color(1f,1f,1f,1f);
        transform.GetComponent<LineRenderer>().endColor = new Color(1f,1f,1f,1f);
        lr.SetWidth(0.03f, 0.03f);
        lr.positionCount = 100;
        lr.material = LRmaterial;

        //lr.material = LRmaterial;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        //lr.material = LRmaterial;
        _multiplier = Camera.main.GetComponentInChildren<ScoreHandler>().GetMultiplier();
        switch (_multiplier)
        {
            case 0:
                transform.GetComponent<LineRenderer>().startColor = new Color(1f,1f,1f);
                transform.GetComponent<LineRenderer>().endColor = new Color(1f,1f,1f);
                break;                      
            case 2:
                transform.GetComponent<LineRenderer>().startColor = new Color(0.3f,0.8f,0.1f);
                transform.GetComponent<LineRenderer>().endColor = new Color(0.3f,0.8f,0.1f);
                break;
            case 4:
                transform.GetComponent<LineRenderer>().startColor = new Color(0.9f,0.4f,0.1f);
                transform.GetComponent<LineRenderer>().endColor = new Color(0.9f,0.4f,0.1f);
                break;
            case 8:
                transform.GetComponent<LineRenderer>().startColor = new Color(0.7f,0.2f,0.6f);
                transform.GetComponent<LineRenderer>().endColor = new Color(0.7f,0.2f,0.6f);
                break; 
                    
        }
        DrawLine(_choice);

        if (_hit)
        {
            _timer += Time.deltaTime;
            
        }
    }

    void DrawLine(int choice)
    {
        _positionX = -2.41f;

        switch (choice)
        {
            case 1:
                for (int i = 0; i < 100; i++)
                {
                    _pieBoi = 2 * Mathf.PI*(_positionX +2.41f) /(4.653f); 

                    _positionX += 0.047f;
                    lr.SetPosition(i, new Vector3(_positionX + 0.04f,0.4f*Mathf.Exp(2f*Mathf.Log(2f/8f)*_timer)*Mathf.Sin(_timer*2*Mathf.PI*8)*Mathf.Sin(8*_pieBoi) + GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.55f, -1f));
                }
                break;
            case 2:
                for (int i = 0; i < 100; i++)
                {
                    _pieBoi = 2 * Mathf.PI*(_positionX +2.41f) /(4.653f);

                    _positionX += 0.047f;
                    lr.SetPosition(i, new Vector3(_positionX + 0.04f,0.2f*Mathf.Exp(2f*Mathf.Log(2f/9f)*_timer)*Mathf.Sin(_timer*2*Mathf.PI*9)*2f*(Mathf.Sin(8*_pieBoi)+Mathf.Sin(16*_pieBoi)) + GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.55f, -1f));
                }
                break;
            case 3:
                for (int i = 0; i < 100; i++)
                {
                    _pieBoi = 2 * Mathf.PI*(_positionX +2.41f) /(4.653f);

                    _positionX += 0.047f;
                    lr.SetPosition(i, new Vector3(_positionX + 0.04f,0.2f*Mathf.Exp(2f*Mathf.Log(1f/5f)*_timer)*Mathf.Sin(_timer*2*Mathf.PI*10)*2f*(Mathf.Sin(8*_pieBoi)+Mathf.Sin(16*_pieBoi)+0.5f*Mathf.Sin(32*_pieBoi)) + GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.55f, -1f));
                }
                break;
            case 4:
                for (int i = 0; i < 100; i++)
                {
                    _pieBoi = 2 * Mathf.PI*(_positionX +2.41f) /(4.653f);

                    _positionX += 0.047f;
                    lr.SetPosition(i, new Vector3(_positionX + 0.04f,0.2f*Mathf.Exp(2f*Mathf.Log(2f/11f)*_timer)*Mathf.Sin(_timer*2*Mathf.PI*11)*(2f*Mathf.Sin(6*_pieBoi)*Mathf.Sin(18*_pieBoi)+Mathf.Sin(_pieBoi))+ GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.55f, -1f));
                }
                break;
            case 5:
                for (int i = 0; i < 100; i++)
                {
                    _pieBoi = 2 * Mathf.PI*(_positionX +2.41f) /(4.653f);

                    _positionX += 0.047f;
                    lr.SetPosition(i, new Vector3(_positionX + 0.04f,0.2f*Mathf.Exp(2f*Mathf.Log(1f/6f)*_timer)*Mathf.Sin(_timer*2*Mathf.PI*12)*(2f*Mathf.Sin(6*_pieBoi)*Mathf.Sin(18*_pieBoi)+Mathf.Sin(_pieBoi)*Mathf.Sin(18*_pieBoi))+ GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.55f, -1f));
                }
                break;       
            
        }     

    }
    public void HitEvent()
    {
         _choice = UnityEngine.Random.Range(1,5);
        //_choice = ; 
        _timer = 0f; 
        _hit = true;
    }
}
