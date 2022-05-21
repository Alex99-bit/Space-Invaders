using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState currentGameState;
    static int scorePlayer;
    public GameObject pause, gameOver, victory, menu;
    Text score;

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
        Time.timeScale = 0;
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        score.text = "Score: " + scorePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            SetGameState(GameState.pause);
        }
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void Reanudar()
    {
        SetGameState(GameState.inGame);
    }

    public void Back()
    {
        SetGameState(GameState.menu);
    }

    public void Salir()
    {
        Application.Quit();
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
            Time.timeScale = 1;
        }
        else if(newGameState == GameState.pause)
        {
            Time.timeScale = 0;
        }
        else if(newGameState == GameState.gameOver)
        {
            Time.timeScale = 1;
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
