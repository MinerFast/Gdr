using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            gameController.currentCoins++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Spike")
        {
            gameController.Lose();
        }
    }
}
