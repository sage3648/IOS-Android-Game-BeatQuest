using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class BasicAudioVisualiser : MonoBehaviour
{
    public float RmsValue;
    public float DbValue;
    public float PitchValue;
    public float PreviousPitchValue; 
    public Text pitchDisplay;
    public float timer;


    public AudioSource TrackToFollow; 
    public bool CanSpawn; 
    public Vector2[] SpawnPositions;
    public float PositionCursor;
    public GameObject Imp, Goblin, Chort;
    public GameObject Player;
    private float _averageTotal; //to add up values to create averages
    private int _averageCountCursor;
    private int counter;
    private bool _musicStarted;
    public float highestHz;
    public float lowestHz; 
  
 
    private const int QSamples = 512;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;
 
    float[] _samples;
    private float[] _spectrum;
    private float _fSample;
 
    void Start()
    {
        TrackToFollow.Play();
        _musicStarted = false; 
        timer = 0;
        CanSpawn = false; 
        PreviousPitchValue = 0f; 
        _averageCountCursor = 0;
        PositionCursor = 0; 
        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;
        lowestHz = 500f; 
    }

    private void LateUpdate()
    {
        if (TrackToFollow.time >= 1.58f && _musicStarted == false)
        {
            _musicStarted = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
      
        if (DbValue <= 1f)
        {
            CanSpawn = true; 
        }

        if (CanSpawn && DbValue > .1f  && PitchValue != 0f)
        {
            GenerateEnemies();
        }
        AnalyzeSound();
    }
    void AnalyzeSound()
    {
        GetComponent<AudioSource>().GetOutputData(_samples, 0); 
        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i]; 
        }
        RmsValue = Mathf.Sqrt(sum / QSamples);
        DbValue = 20 * Mathf.Log10(RmsValue / RefValue); 
        if (DbValue < -160) DbValue = -160; 
        GetComponent<AudioSource>().GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++)
        { 
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                continue;
            maxV = _spectrum[i];
            maxN = i;
        }
        float freqN = maxN;
        if (maxN > 0 && maxN < QSamples - 1)
        { 
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        PitchValue = freqN * (_fSample / 2) / QSamples;
        pitchDisplay.text = PitchValue + "hZ"; 
    }

    void GenerateEnemies()
    {
        CanSpawn = false; 
        //positon 1
        if (PitchValue < 300f)
        {
            PositionCursor = -2f; 
        }
        //position 2
        if (PitchValue > 300f && PitchValue < 341.8f)
        {
            PositionCursor = -1f; 
        }
        //position 3 mid
        if(PitchValue > 341.8 && PitchValue < 365.2f)
        {
            PositionCursor = 0f;
        }
        //position 4
        if (PitchValue > 365.2 && PitchValue < 395)
        {
            PositionCursor = 1f; 
        }
        //position 5
        if (PitchValue > 395)
        {
            PositionCursor = 2f; 
        }
            
        Instantiate(Goblin, new Vector2(PositionCursor, Player.transform.position.y + 10), transform.rotation); 
    }
    
}
