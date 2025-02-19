using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreUI : BaseUI
{
    TextMeshProUGUI scoreText;
    TextMeshProUGUI bestScoreText;

    Button startButton;
    Button exitButton;


    // Start is called before the first frame update
    protected override UIState GetUIState()
    {
        return UIState.Score;
    }

    public override void Init(MiniGameUIManager_1 uiManager)//오버라이드를 해주어야 명확히 HomeUI의 Init으로 구분하여 문제발생 방지
    {
        base.Init(uiManager);//부모클래스의 메서드를 호출 uiManager를 따로 선언해주지 않아도 부모클래스에서 선언해주어 따로 선언필요x

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();

        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);

    }


    public void SetUI(int score,  int bestScore)
    {
        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    void OnClickStartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }
}
