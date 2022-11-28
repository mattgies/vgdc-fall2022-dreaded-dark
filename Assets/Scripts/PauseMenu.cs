using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ResetGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        //some code to reset you to the beginning of the level
    }

    public void GoToControlsMenu()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void Back(){
        pauseMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void GoToMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }


    public void QuitGame(){
        Application.Quit();
    }
}
