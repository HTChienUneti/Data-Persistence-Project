using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMainUI : MonoBehaviour
{
    static public CanvasMainUI Instance;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Button backMenuButton;

    private void Start()
    {
        Instance = this;
        if (DataManager.Instance != null)
        {
            LoadBestScore();

        }
        backMenuButton.onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadBestScore()
    {
        if(DataManager.Instance!=null)
        {
            if(DataManager.Instance.playerNameBest !="")
            {
                bestScoreText.text = "Best score: "
            + DataManager.Instance.playerNameBest + ": " + DataManager.Instance.score;
            }
            else
            {
                bestScoreText.text = "Best socre: 0";
            }
        }
        
    }
}
