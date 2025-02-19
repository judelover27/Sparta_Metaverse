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

    public override void Init(MiniGameUIManager_1 uiManager)//�������̵带 ���־�� ��Ȯ�� HomeUI�� Init���� �����Ͽ� �����߻� ����
    {
        base.Init(uiManager);//�θ�Ŭ������ �޼��带 ȣ�� uiManager�� ���� ���������� �ʾƵ� �θ�Ŭ�������� �������־� ���� �����ʿ�x

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
