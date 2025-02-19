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


        homeUI = GetComponentInChildren<HomeUI>(true);//매개변수 true는 꺼져있는 오브젝트까지 가져온다는뜻
        homeUI?.Init(this);//각 클래스 초기화

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

    public void OnClickExit()//전처리기 문법을 통해 유니티 에디터가 정의 되어있을때만실행 빌드마다 다른 명령 가능
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
