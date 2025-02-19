using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public enum UIState
{
    Home,
    Game,
    Score
}

public class MiniGameUIManager_1 : MonoBehaviour
{
    static MiniGameUIManager_1 instance;

    public static MiniGameUIManager_1 Instance
    { get { return instance; } }

    UIState currentState = UIState.Home;
    HomeUI homeUI = null;
    GameUI gameUI = null;
    ScoreUI scoreUI = null;

    private void Awake()
    {
        instance = this;


        homeUI = GetComponentInChildren<HomeUI>(true);//�Ű����� true�� �����ִ� ������Ʈ���� �����´ٴ¶�
        homeUI?.Init(this);//�� Ŭ���� �ʱ�ȭ

        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this);

        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI?.Init(this);

        ChangeState(UIState.Home);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        MiniGameGameManager_1.Instance.Restart();
        ChangeState(UIState.Game);
    }

    public void OnClickExit()//��ó���� ������ ���� ����Ƽ �����Ͱ� ���� �Ǿ������������� ���帶�� �ٸ� ��� ����
    {

    }

    public void UpdateScore()
    {
        gameUI.SetUI(MiniGameGameManager_1.Instance.Score);
    }

    public void SetScoreUI()
    {
        scoreUI.SetUI(MiniGameGameManager_1.Instance.Score, MiniGameGameManager_1.Instance.BestScore);
    }
}
