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

    public override void Init(MiniGameUIManager_1 uiManager)//�������̵带 ���־�� ��Ȯ�� HomeUI�� Init���� �����Ͽ� �����߻� ����
    {
        base.Init(uiManager);//�θ�Ŭ������ �޼��带 ȣ�� uiManager�� ���� ���������� �ʾƵ� �θ�Ŭ�������� �������־� ���� �����ʿ�x

        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent<Button>();

        startButton.onClick.AddListener(OnClickStartButton);//�ڵ� �������� Ȯ�强�� ���� �߰��ܰ� �־���
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
