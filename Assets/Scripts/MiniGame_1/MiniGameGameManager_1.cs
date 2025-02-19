using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameGameManager_1 : MonoBehaviour
{

    private static MiniGameGameManager_1 instance;
    public static MiniGameGameManager_1 Instance { get { return instance; } }
    
    private int score = 0;
    public int Score { get { return score; } }

    int bestScore = 0;
    public int BestScore { get => bestScore; }

    private void Awake()
    {
        instance = this;
    }

    public void Restart() 
    {

    }
}
