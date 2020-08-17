using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    private GameObject start;
    private GameObject levelSelect;
    
    void Start()
    {
        start = GameObject.FindWithTag("StartMenu");
        levelSelect = GameObject.FindWithTag("LevelSelect");
        levelSelect.SetActive(false);
        
    }

    public void StartGame (int startGame)
    {
        SceneManager.LoadScene(startGame);
    }
    public void LevelSelect ()
    {
        levelSelect.SetActive(true);
        start.SetActive(false);
    }

    public void ExitGame ()
    {
        Application.Quit();
    }

    public void Level1 ()
    {

    }
    public void Level2 ()
    {

    }
    public void Level3 ()
    {

    }
    public void BackToMainMenu ()
    {
        levelSelect.SetActive(false);
        start.SetActive(true);
    }
    
}
