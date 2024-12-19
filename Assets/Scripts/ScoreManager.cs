using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DataPersistence;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreList;

    // Start is called before the first frame update
    void Start()
    {
        DataPersistence dp = DataPersistence.Instance;
      
        if(dp != null)
        {
            SaveData bestMatch = dp.GetBestScore();
            ScoreList.text = $"{bestMatch.playerName}: {bestMatch.bestScore}";
        }
        else
        {
            ScoreList.text = $"No have matches :(";
        }
        
    }

   
}
