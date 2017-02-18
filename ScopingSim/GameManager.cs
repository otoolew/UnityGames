using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]
public class LevelInfo
{
    public string LevelID = "Enter Scene Name Here.";
    public string PlayerFacingName = "A snappy Name";
}

public class GameManager : MonoBehaviour
{   
    public static GameManager current;
    [Header("Managers")]
    public HUDManagerUI HUDManager;


    [Header("All Levels Info")]
    //public List<LevelInfo> LevelList;

    [Header("Current Level Info")]
    public int CurrentLevel = 0;

    [Header("Menu Screens")]
    public UnityEngine.GameObject PauseScreen;

    [Header("Events")]

    public Animator Fader;

    [Header("Menu Bools")]
    private bool isInMenuOverlay = false;
    //Private variables
    bool currentLevelComplete = false;

    private void Awake()
    {
        current = this;
        PauseScreen.SetActive(false);
    }

    //public LevelInfo GetCurrentLevelInfo()
    //{
    //return LevelList[CurrentLevel];
    //}

    private void Start()
    {
        //SceneManager.LoadScene(LevelList[CurrentLevel].LevelID, mode: LoadSceneMode.Additive);           
        //StartCoroutine(FirstLevelCoroutine());
    }

    IEnumerator FirstLevelCoroutine()
    {
        yield return new WaitForSeconds(4f);
    }

    private void AdvanceLevel()
    {
        ////If the current level we're in is already complete, wait.
        //if (currentLevelComplete)
        //    return;

        //CurrentLevel++;

        //if (CurrentLevel <= LevelList.Count - 1)
        //{
        //    currentLevelComplete = true;
        //    StartCoroutine(AdvanceLevelCoroutine());
        //}
        //else
        //{
        //    Debug.Log("You win! No more levels left!");
        //    currentLevelComplete = false;
        //    SetFadeState(true);

        //    StartCoroutine(ResetGameAfterYouBeatIt());
        //}
    }

    private IEnumerator ResetGameAfterYouBeatIt()
    {
        yield return new WaitForSeconds(3f);

        CurrentLevel--;
        ResetGame();
    }

    public bool ResetLevel()
    {
        if (!currentLevelComplete)
        {
            StartCoroutine(ResetLevelCoroutine());
            return true;
        }
        else
            return false;
    }

    public void ResetGame()
    {
        if (!currentLevelComplete)
        {
            StartCoroutine(ResetGameCoroutine());
        }
    }

    IEnumerator ResetLevelCoroutine()
    {
        currentLevelComplete = true;
        yield return new WaitForSeconds(1f);
        SetFadeState(true);


        yield return new WaitForSeconds(1f);
        //SceneManager.UnloadSceneAsync(LevelList[CurrentLevel].LevelID);
        //SceneManager.LoadScene(LevelList[CurrentLevel].LevelID, mode: LoadSceneMode.Additive);          

        SetFadeState(false);
        yield return new WaitForSeconds(1f);
        currentLevelComplete = false;
    }

    IEnumerator ResetGameCoroutine()
    {
        currentLevelComplete = true;
        yield return new WaitForSeconds(1f);
        SetFadeState(true);
        yield return new WaitForSeconds(1f);

        yield return null;

        //SceneManager.UnloadSceneAsync(LevelList[CurrentLevel].LevelID);
        CurrentLevel = 0;
        //SceneManager.LoadScene(LevelList[0].LevelID, mode: LoadSceneMode.Additive);
        SetFadeState(false);
        yield return new WaitForSeconds(1f);
        currentLevelComplete = false;
    }

    IEnumerator AdvanceLevelCoroutine()
    {
        //TODO: End of Level Show

        yield return new WaitForSeconds(1f);
        SetFadeState(true);

        yield return new WaitForSeconds(1f);
        //move obstacles so on trigger exit is called - Dan


        yield return new WaitForSeconds(1f);

        SetFadeState(false);

        //SceneManager.UnloadSceneAsync(LevelList[CurrentLevel - 1].LevelID);
        //SceneManager.LoadScene(LevelList[CurrentLevel].LevelID, mode: LoadSceneMode.Additive);


        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(3f);

        currentLevelComplete = false;

    }

    public void SetPauseMenu(bool visible)
    {
        isInMenuOverlay = visible;
        if (isInMenuOverlay)
        {
            PauseScreen.SetActive(true);
        }
        else
        {
            PauseScreen.SetActive(false);
        }
    }

    public void TogglePauseMenu()
    {
        SetPauseMenu(!isInMenuOverlay);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            TogglePauseMenu();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            AdvanceLevel();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            ResetLevel();
        }
    }

    public void CheckIfLevelComplete()
    {

    }

    private void SetFadeState(bool fade)
    {
        Fader.SetBool("FadeTowardsBlack", fade);
    }

    /* Pause Menu Buttons */

    public void RestartLevel()
    {
        Debug.Log("Restarting...");
        ResetLevel();
    }

    public void ShowLevelSelect()
    {

    }

    public void ShowControls()
    {

    }

    public void HideControls()
    {

    }

    public void QuitAnimation()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

}


