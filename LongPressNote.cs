using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class LongPressNote : MonoBehaviour
{
    private bool visible; 
    private LineRenderer line;
   //public int VertexCount; 
    public bool start_of_note; 
    public Material Material;
   // public GameObject[] Positions;
    public bool being_hit; 
    
    // Start is called before the first frame update
    void Start()
    {
        visible = false; 
        //VertexCount = 2; 
        being_hit = false; 
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;
        line.material = Material; 
        line.SetWidth(0.09f, 0.09f);
    }


    void ConnectNearestNode()
    {
        GameObject nearestUpper = NearestUpperNote(); 
        if (nearestUpper != null && NearestUpperNote().GetComponentInChildren<LongPressNote>().start_of_note == false)
        {
            line.positionCount = 2; 
            line.SetPosition(0, gameObject.transform.position);
            line.SetPosition(1, NearestUpperNote().transform.position);
        }
    }

    GameObject PopulateNoteArray(GameObject startingPoint)
    {
        GameObject[] AllLongNotes = GameObject.FindGameObjectsWithTag("LongPress");

        GameObject closest = null;
        float distance = Mathf.Infinity;
        foreach (GameObject go in AllLongNotes)
        {

            Vector3 position = startingPoint.transform.position;

            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                if (go.transform.position.y > startingPoint.transform.position.y)
                {
                    closest = go;
                }
                distance = curDistance;
            }
        }
        return closest;
    }
    
    
    GameObject NearestUpperNote()
    {
        GameObject[] AllLongNotes = GameObject.FindGameObjectsWithTag("LongPress");

        GameObject closest = null;
        float distance = Mathf.Infinity;
        foreach (GameObject go in AllLongNotes)
        {

            Vector3 position = gameObject.transform.position;

            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && go.transform.position.y > gameObject.transform.position.y + 1f)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void OnBecameVisible()
    {
        visible = true;
    }

    // Update is called once per frame
    void Update()
    {
       
       
        if (visible)
        {
            ConnectNearestNode();
        }
           // line.positionCount = VertexCount;
          // line.SetPosition(0 ,gameObject.transform.position);
            
           /* for (int i = 1; i < VertexCount; i++)
            {
                line.SetPosition(i,NearestUpperNote().transform.position);
            }*/
            /*foreach (GameObject go in Positions)
            {
                VertexCount++; 
                line.positionCount = VertexCount;
                line.SetPosition(VertexCount -1 ,go.transform.position);
                //  VertexCount++;
            }*/

            if (being_hit)
            {
                if (!NearestUpperNote().GetComponentInChildren<LongPressNote>().start_of_note)
                {
                    transform.position = Vector2.MoveTowards(transform.position, NearestUpperNote().transform.position, 0.6f);

                }
                // transform.position = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x,
                // gameObject.transform.position.y); 
            }

            //Completed Line
            GameObject nearestUpper = NearestUpperNote(); 
           if (nearestUpper != null && transform.position.y >= NearestUpperNote().transform.position.y)
            {
                Destroy(gameObject);
            }

            //Missed long press
            if (GameObject.FindGameObjectWithTag("Player").transform.position.y > transform.position.y + 1f)
            {
                //Destroy(gameObject);
            }
    }
    
    
    public GameObject FindLongPress()
    {
        GameObject[] Enemys;
        Enemys = GameObject.FindGameObjectsWithTag("LongPress");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
		
        foreach (GameObject go in Enemys)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance; 
            }
        }
        return closest; 
    }
}
