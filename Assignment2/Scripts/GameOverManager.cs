using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    Canvas canvas;
    GameObject player;
    public Text gameOverMessage;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (PlayerController.dead||InfectedManager.infected>4)
        {
            gameOverMessage.text = "You Lose!";
            PlayerController.dead = false;         
            player.GetComponent<Weapon>().enabled = !player.GetComponent<Weapon>().enabled;
            canvas.enabled = !canvas.enabled;
            Pause();
            InfectedManager.infected = 0;
        }
        if (ScoreManager.kills>=45)
        {
            gameOverMessage.text = "You Won!";          
            PlayerController.dead = false;
            InfectedManager.infected = 0;
            player.GetComponent<Weapon>().enabled = !player.GetComponent<Weapon>().enabled;
            canvas.enabled = !canvas.enabled;
            Pause();
            ScoreManager.kills = 0;
        }
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;

    }

    public void Quit()
    {
		Application.Quit();
    }
}
