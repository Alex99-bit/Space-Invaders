using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMecha : MonoBehaviour
{
    Rigidbody playerRB;
    float speed;

    private void Awake()
    {
        // Object pooling: balas del player
        for(int i = 0; i < 10; i++)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        speed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        // Solo se ejecuta en caso de que este en modo jugar
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            Movimiento();
        }
        else if(GameManager.sharedInstance.currentGameState == GameState.menu)
        {
            // Si esta en el menu inicial, restaura todo

        }
    }

    void Movimiento()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRB.velocity.y);
    }

    void Disparo()
    {

    }
}
