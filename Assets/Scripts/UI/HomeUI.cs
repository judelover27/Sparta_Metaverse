using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    Button startButton;
    Button exitButton;

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }

    public override void Init(MiniGameUIManager_1 uiManager)//오버라이드를 해주어야 명확히 HomeUI의 Init으로 구분하여 문제발생 방지
    {
        base.Init(uiManager);//부모클래스의 메서드를 호출 uiManager를 따로 선언해주지 않아도 부모클래스에서 선언해주어 따로 선언필요x

        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);//코드 보수성과 확장성을 위해 중간단계 넣어줌
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }

    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }
}
