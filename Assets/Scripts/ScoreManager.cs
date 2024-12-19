using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public string filePath;

    private void Awake()
    {
        Instance = this;
        filePath = Application.persistentDataPath + "/savefile.json";
    }


    [System.Serializable]
    public class ScoreEntry
    {
        public int bestScore;
        public string playerName;

        public ScoreEntry(string playerName, int bestScore)
        {
            this.playerName = playerName;
            this.bestScore = bestScore;
        }
    }

    [System.Serializable]
    public class ScoreData
    {
        public List<ScoreEntry> scores = new List<ScoreEntry>(); //Lista com os jogadores e seus scores
    }

    public void AddScore(string playerName, int score)
    {

        ScoreData scoreData = LoadScores(); //Carrega todos os scores

        scoreData.scores.Add(new ScoreEntry(playerName, score)); //Adiciona novos valor a lista

        scoreData.scores.Sort((a, b) => b.bestScore.CompareTo(a.bestScore)); //Ordena a lista da menor pontuação para a maior

        if (scoreData.scores.Count > 10) //Limita a lista a no maximo 10 itens
        {
            scoreData.scores.RemoveAt(10);
        }

        SaveScores(scoreData);
    }

    public ScoreData LoadScores()
    {
        if (File.Exists(filePath)) //Verifica se o arquivo existe caso não cria um novo objeto de ScoreData
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<ScoreData>(json);
        }

        return new ScoreData();
    }

    public void SaveScores(ScoreData scoreData)
    {
        string json = JsonUtility.ToJson(scoreData, true);
        File.WriteAllText(filePath, json);
        Debug.Log($"Scores salvos em: {filePath}");
    }


    //Existe apenas para testes
    public void DeleteScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save deleted!");
        }
    }

}
