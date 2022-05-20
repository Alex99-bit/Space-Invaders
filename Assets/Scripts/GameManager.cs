using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState currentGameState;
    static int scorePlayer;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        scorePlayer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        
    }

    // Se gestiona el estado del juego
    public void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {
            Time.timeScale = 0;
        }
        else if(newGameState == GameState.inGame)
        {
            Time.timeScale = 0;
        }
        else if(newGameState == GameState.pause)
        {
            Time.timeScale = 0;
        }
        else if(newGameState == GameState.gameOver)
        {

        }
    }

    public int GetScore()
    {
        return scorePlayer;
    }

    public void SetScore(int score)
    {
        scorePlayer = score;
    }
}

public enum GameState
{
    menu,
    pause,
    inGame,
    gameOver
}
