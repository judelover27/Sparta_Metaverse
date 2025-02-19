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

    public override void Init(MiniGameUIManager_1 uiManager)//�������̵带 ���־�� ��Ȯ�� HomeUI�� Init���� �����Ͽ� �����߻� ����
    {
        base.Init(uiManager);//�θ�Ŭ������ �޼��带 ȣ�� uiManager�� ���� ���������� �ʾƵ� �θ�Ŭ�������� �������־� ���� �����ʿ�x

        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();

    }

    public void SetUI(int score)
    {
        scoreText.text = score.ToString();
    }
}
