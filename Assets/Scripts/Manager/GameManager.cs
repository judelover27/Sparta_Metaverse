using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public ScoreBoardManager scoreBoardManager;
    private const string ScoreBoardKey = "ShowScoreBoard";


    private void Awake()
    {
        instance = this;

        if(ScoreBoardKey == null)
        scoreBoardManager = FindAnyObjectByType<ScoreBoardManager>();

        if (scoreBoardManager == null)
            Debug.Log("ScoreBoardKey is null");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            scoreBoardManager.HideScoreBoard();
        }
    }

    public void GameEnd() //전처리기문 빌드별 종료
    { 
        Debug.Log("game end");
        PlayerPrefs.DeleteKey(ScoreBoardKey); // ScoreBoard 상태 초기화
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID || UNITY_IOS
        Application.Quit();
#else
        Application.Quit();
#endif
    }
}
