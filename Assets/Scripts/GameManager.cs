using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState currentGameState;
    static int scorePlayer,vida,lvl;
    public bool cambioNivel;
    public GameObject pause, gameOver, victory, menu;
    Text score,health;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        scorePlayer = 0;
        lvl = 0;
        cambioNivel = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        scorePlayer = 0;
        vida = 5;
        score.text = "Score: " + scorePlayer;
        health.text = "Health: " + vida;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") && currentGameState == GameState.inGame)
        {
            SetGameState(GameState.pause);
        }

        score.text = "Score: " + scorePlayer;
        health.text = "Health: " + vida;

        // Cambio de nivel
        if(scorePlayer == 480 && lvl == 0)
        {
            // Pasa al segundo nivel
            lvl = 1;
            cambioNivel = true;
        }
        else if(scorePlayer == 960 && lvl == 1)
        {
            // Pasa al tercer nivel
            lvl = 2;
            cambioNivel = true;
        }
        else if(scorePlayer == 1440 && lvl == 2)
        {
            // Gana la partida
            SetGameState(GameState.victory);
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

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
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
            menu.SetActive(true);
            scorePlayer = 0;
            lvl = 0;
            score.text = "Score: "+scorePlayer;
            cambioNivel = false;
        }
        else if(newGameState == GameState.inGame)
        {
            Time.timeScale = 1;
        }
        else if(newGameState == GameState.pause)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
        else if(newGameState == GameState.gameOver)
        {
            Time.timeScale = 1;
            gameOver.SetActive(true);
        }
        else if(newGameState == GameState.victory)
        {
            Time.timeScale = 0;
            victory.SetActive(true);
        }

        currentGameState = newGameState;
    }

    public int GetScore()
    {
        return scorePlayer;
    }

    public void SetScore(int score)
    {
        scorePlayer = score;
    }

    public void SetVida(int health)
    {
        vida = health;
    }

    public int GetVida()
    {
        return vida;
    }
}

public enum GameState
{
    menu,
    pause,
    inGame,
    gameOver,
    victory
}
