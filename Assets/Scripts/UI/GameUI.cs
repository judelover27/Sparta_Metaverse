using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : BaseUI
{
    TextMeshProUGUI scoreText;


    protected override UIState GetUIState()
    {
        return UIState.Game;
    }

    public override void Init(MiniGameUIManager_1 uiManager)//오버라이드를 해주어야 명확히 HomeUI의 Init으로 구분하여 문제발생 방지
    {
        base.Init(uiManager);//부모클래스의 메서드를 호출 uiManager를 따로 선언해주지 않아도 부모클래스에서 선언해주어 따로 선언필요x

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();

    }

    public void SetUI(int score)
    {
        scoreText.text = score.ToString();
    }
}
