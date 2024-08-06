using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenuUI : MonoBehaviour
{
    static public CanvasMenuUI Instance;
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI BestScoreText;
    private void Start()
    {
        Instance = this;
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        if (DataManager.Instance.playerNameBest != "")
        {
            BestScoreText.text = "Best score: " + DataManager.Instance.playerNameBest + ": " + DataManager.Instance.score;
        }
        else
        {
            BestScoreText.text = "Best score: 0";
        }
    }
    private void StartGame()
    {
        SceneManager.LoadScene("main");
    }
    private void QuitGame()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }

    }
    public void SavePlayerName()
    {
        DataManager.Instance.SavePlayerNameCurrent(playerName.text);
    }
}
