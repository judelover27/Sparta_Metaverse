using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameGameManager_1 : MonoBehaviour
{
    public JumpPlayerController jumpPlayerController;
    private static MiniGameGameManager_1 instance;
    public static MiniGameGameManager_1 Instance { get { return instance; } }
    
    private int score = 0;
    public int Score { get { return score; } }

    int bestScore = 0;
    public int BestScore { get => bestScore; }

    public Vector2 initPosition = new Vector3(-9.5f, 0, 0);
    public float initJumpPower = 15f;

    private void Awake()
    {
        instance = this;
        jumpPlayerController = FindAnyObjectByType<JumpPlayerController>();
    }

    public void Restart() 
    {
        MiniGameUIManager_1.Instance.ChangeState(UIState.Game);

        Invoke("SetIsDeadFalse", 0.1f);
        jumpPlayerController.transform.position = initPosition;
        jumpPlayerController.Jump(new Vector2(1,1), initJumpPower);
    }

    private void SetIsDeadFalse()
    {
        jumpPlayerController.IsDead = false;
    }

    public void AddScore(int addScore)
    {
        score += addScore;
    }
}
