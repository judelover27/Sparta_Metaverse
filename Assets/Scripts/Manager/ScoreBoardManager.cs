using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoardManager : MonoBehaviour
{
    public GameObject scoreBoardUI; // ���ھ� ���� UI ������Ʈ
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
            // �̴ϰ��� �� ���ƿ� ��� Ȱ��ȭ
            scoreBoardUI.SetActive(true);
        }
    }

    public void ShowScoreBoard()
    {
        PlayerPrefs.SetInt(ScoreBoardKey, 1); // ScoreBoard�� Ȱ��ȭ�� ���¸� ����
        PlayerPrefs.Save();
        scoreBoardUI.SetActive(true);
    }

    public void HideScoreBoard()
    {
        scoreBoardUI.SetActive(false);
        PlayerPrefs.DeleteKey(ScoreBoardKey); // ScoreBoard ���� �ʱ�ȭ

    }
}

