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

    MiniGameGameManager_1 miniGameGameManager_1;
    UIState currentState = UIState.Home;
    HomeUI homeUI = null;
    GameUI gameUI = null;
    ScoreUI scoreUI = null;

    private int score = 0;
    public int Score { get { return score; } set { score = value; } }

    int bestScore = 0;
    public int BestScore { get => bestScore; }
    private const string BestScoreKey = "BestScore";

    private void Awake()
    {
        instance = this;
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        miniGameGameManager_1 = MiniGameGameManager_1.Instance;
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

    public void OnClickExit()//
    {
        PlayerPrefs.SetInt("ShowScoreBoard", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScene");

    }

    public void UpdateScore()
    {
        gameUI.SetUI(score);
    }

    public void SetScoreUI()
    {
        scoreUI.SetUI(score, bestScore);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        UpdateScore();
    }

    public void UpdateBestScore()
    {
        if (score >= bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
            PlayerPrefs.Save();
        }
    }
}
