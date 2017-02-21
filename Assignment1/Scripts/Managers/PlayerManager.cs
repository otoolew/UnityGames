using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    public static float lives;
    public Text livesText; 
	// Use this for initialization
	void Start () {
        lives = 3;
        livesText.text = "Lives: " + lives;
    }

	// Update is called once per frame
	void Update () {
        
        if (lives < 0f)
        {
            ReloadCurrentScene();
            return;
        }
        livesText.text = "Lives: " + lives;
    }
    public void ReloadCurrentScene()
    {
        // get the current scene name 
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(0);
        // load the same scene
        //SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
