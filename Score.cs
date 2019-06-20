using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Score
    {
        public void SetLevelScore(float gameScore, String levelName)
        {
            if (gameScore > PlayerPrefs.GetFloat(levelName))
            {
                PlayerPrefs.SetFloat(levelName, gameScore);
            }
        }
    
        public float GetLevelScore(String levelName)
        {
            return PlayerPrefs.GetFloat(levelName); 
        }
    }
}