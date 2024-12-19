using UnityEngine;
using UnityEngine.UI;

public class ScoreUIHandle : MonoBehaviour
{
    public Text ScoreList;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager data = ScoreManager.Instance;

        if (data == null)
        {
            ScoreList.text = $"No have matches :(";
            return;
        }

        var scoreData = data.LoadScores();

        foreach (var entry in scoreData.scores)
        {
            ScoreList.text += $"{entry.playerName}, Score: {entry.bestScore} \n";
        }
    }
}