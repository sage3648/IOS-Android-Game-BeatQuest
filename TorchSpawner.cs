using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchSpawner : MonoBehaviour
{
    private float _songTime;
    private float _targetTime;
    public AudioSource SongToTrack;

    public GameObject LeftTorch;
    public GameObject RightTorch;
    // Start is called before the first frame update
    void Start()
    {
        _targetTime = 1.85f; 
    }

    // Update is called once per frame
    void Update()
    {
        _songTime = SongToTrack.time;
        if (_songTime >= _targetTime)
        {
            Instantiate(LeftTorch, new Vector2(-2.25f, GameObject.FindGameObjectWithTag("Player").transform.position.y + 10),
                GameObject.FindGameObjectWithTag("Player").transform.rotation); 
            Instantiate(RightTorch, new Vector2(2.25f, GameObject.FindGameObjectWithTag("Player").transform.position.y + 10),
                GameObject.FindGameObjectWithTag("Player").transform.rotation); 
            _targetTime += 0.9022556391f; 
        }
    }
}
