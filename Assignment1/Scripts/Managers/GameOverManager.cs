using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
    public static float lives = 3f;
    public Text livesText;
    // Use this for initialization
    void Start()
    {

    }
    void Awake()
    {
        livesText.text = "Lives: " + lives;
    }
    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + lives;
        if (lives == 0)
        {
            SceneManager scene = new SceneManager();

        }
    }
}
