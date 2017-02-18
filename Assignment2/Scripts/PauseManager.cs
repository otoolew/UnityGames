using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class PauseManager : MonoBehaviour {

    Canvas canvas;
    GameObject player;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.GetComponent<Weapon>().enabled = !player.GetComponent<Weapon>().enabled;
            canvas.enabled = !canvas.enabled;
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
      
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}
