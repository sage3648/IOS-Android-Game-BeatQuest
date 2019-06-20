using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeConnector : MonoBehaviour
{
    private LineRenderer line;
    public bool start_of_note;
    public Material Material;
    private bool visible;
    public bool BeingHit; 


    // Start is called before the first frame update
    void Start()
    {
        BeingHit = false; 
        visible = false;
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = 0;
        line.material = Material; 
        line.SetWidth(0.09f, 0.09f);
    }

    // Update is called once per frame
    void Update()
    {
        if (visible)
        {
            ConnectNodes();
        }

        if (BeingHit)
        {
            transform.position = Vector2.MoveTowards(transform.position, FindNextNode().transform.position, 0.6f);
            BeingHit = false; 
        }
    }

    void ConnectNodes()
    {
        GameObject toJoin = FindNextNode();
        if (toJoin != null && toJoin.GetComponentInChildren<NodeConnector>().start_of_note == false)
        {
            line.positionCount = 2; 
            line.SetPosition(0,gameObject.transform.position);
            line.SetPosition(1, toJoin.transform.position); 
        }
    
    }

    private void OnBecameVisible()
    {
        visible = true; 
    }

    GameObject FindNextNode()
    {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("LongPress");
        float distance = 9999999;
        GameObject temp = null;
        foreach (GameObject go in nodes)
        {
            float difference = go.transform.position.y - gameObject.transform.position.y;
            if (difference < distance && go.transform.position.y > gameObject.transform.position.y)
            {
                distance = difference;
                temp = go;
            }
        }
        return temp;
    }
}
