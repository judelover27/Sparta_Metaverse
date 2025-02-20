using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoardManager : MonoBehaviour
{
    public GameObject scoreBoardUI; // 스코어 보드 UI 오브젝트
    private const string ScoreBoardKey = "ShowScoreBoard";
    private const string BestScoreKey = "BestScore";
    public TextMeshProUGUI bestScoreText;
    private int bestScore;

    private void Start()
    {
        if (scoreBoardUI == null)
            scoreBoardUI = FindAnyObjectByType<ScoreBoardManager>().gameObject;
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        bestScoreText.text = bestScore.ToString();

        if (PlayerPrefs.GetInt(ScoreBoardKey,0) == 0)
        {
            scoreBoardUI.SetActive(false);
        }
        else
        {
            // 미니게임 후 돌아온 경우 활성화
            scoreBoardUI.SetActive(true);
        }
    }

    public void ShowScoreBoard()
    {
        PlayerPrefs.SetInt(ScoreBoardKey, 1); // ScoreBoard를 활성화한 상태를 저장
        PlayerPrefs.Save();
        scoreBoardUI.SetActive(true);
    }

    public void HideScoreBoard()
    {
        scoreBoardUI.SetActive(false);
        PlayerPrefs.DeleteKey(ScoreBoardKey); // ScoreBoard 상태 초기화

    }
}

