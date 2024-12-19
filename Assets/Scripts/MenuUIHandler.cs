using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField nameInput;
    public Text msgText;

    public void StartGame()
    {
        string playerName = nameInput.text.ToString();

        if (playerName != "") {
            DataPersistence.Instance.playerName = playerName;
            SceneManager.LoadScene(1);
        }

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToHighScore()
    {
        SceneManager.LoadScene(2);
    }
}
