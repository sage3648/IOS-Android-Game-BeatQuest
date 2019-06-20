using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class HitMarkerBehavior : MonoBehaviour
{
    public int segments;
    public float radius;
    LineRenderer line;
    private float _opacityModifier;
    private int _multiplier;
    public bool InnerCircle;
    public Material Material;
    public Material Mat2X;
    public Material Mat4X;
    public Material Mat8X; 
       
    void Start ()
    {
        InnerCircle = false;
        //line.startWidth = 1f;
        _multiplier = 0; 
        //line.endWidth = 1f; 
        _opacityModifier = 0f; 
        segments = 35;
        radius = 4; 
        line = gameObject.GetComponent<LineRenderer>();
       
        line.SetVertexCount (segments + 1);
        line.useWorldSpace = false;
        
        
        
        
        line.material = Material; 
        line.SetWidth(0.02f, 0.02f);
    }

    private void Update()
    {
        float score = Camera.main.GetComponentInChildren<ScoreHandler>().Streak;

        if (score < 10)
        {
            line.material = Material; 
        }
        if (score >= 10)
        {
            line.material = Mat2X; 
        }
        if (score >= 30)
        {
            line.material = Mat4X; 
        }
        if (score >= 50)
        {
            line.material = Mat8X; 
        }
        
       
        
       
        float difference = transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y + 1.5f;
        if (difference >= 8f)
        {
            
            transform.GetComponent<LineRenderer>().startColor = new Color(1f,1f,1f,0f);
            transform.GetComponent<LineRenderer>().endColor = new Color(1f,1f,1f,0f);

        }
        else if (!InnerCircle)
        {
            _opacityModifier += Time.deltaTime * 0.7f; 
            _multiplier = Camera.main.GetComponentInChildren<ScoreHandler>().GetMultiplier(); 
            switch (_multiplier)
            {
                case 0:
                    transform.GetComponent<LineRenderer>().startColor = new Color(1f,1f,1f,_opacityModifier);
                    transform.GetComponent<LineRenderer>().endColor = new Color(1f,1f,1f,_opacityModifier);
                    break;                      
                case 2:
                    transform.GetComponent<LineRenderer>().startColor = new Color(0.3f,0.8f,0.1f,_opacityModifier);
                    transform.GetComponent<LineRenderer>().endColor = new Color(0.3f,0.8f,0.1f,_opacityModifier);
                    break;
                case 4:
                    transform.GetComponent<LineRenderer>().startColor = new Color(0.9f,0.4f,0.1f,_opacityModifier);
                    transform.GetComponent<LineRenderer>().endColor = new Color(0.9f,0.4f,0.1f,_opacityModifier);
                    break;
                case 8:
                    transform.GetComponent<LineRenderer>().startColor = new Color(0.7f,0.2f,0.6f,_opacityModifier);
                    transform.GetComponent<LineRenderer>().endColor = new Color(0.7f,0.2f,0.6f,_opacityModifier);
                    break; 
                    
            }
        }

        if (InnerCircle)
        {
            radius = 0.69f; 
            transform.GetComponent<LineRenderer>().startColor = new Color(0.1f,0.1f,0.1f,0.25f);
            transform.GetComponent<LineRenderer>().endColor = new Color(0.1f,0.1f,0.1f,0.25f);
        }
        else
        {
            if (radius <= 0.69f)
            {
            
            }
            else
            {
                radius = difference/3; 
            }    
        }

        
        CreatePoints ();
    }

    void CreatePoints ()
    {
        float x;
        float y;
        float z = -1f;
       
        float angle = 0f;
       
        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin (Mathf.Deg2Rad * angle);
            y = Mathf.Cos (Mathf.Deg2Rad * angle);
            line.SetPosition (i,new Vector3(x,y,z) * radius);
            angle += (360f / segments);
        }
    }


 
}
