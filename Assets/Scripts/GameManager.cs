using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int HighScore = 0;

    public static void GameOver()
    {
        Contador.GameOver();
    }

    public static void SetNewHighScore(int score)
    {
        if (score > HighScore)
            HighScore = score;
    }

    public static int GetHighScore()
    {
        return HighScore;
    }
}
