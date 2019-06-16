using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    GameObject scroll;
    GameObject charSheet;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            scroll = GameObject.FindGameObjectWithTag("menu");
            scroll.SetActive(false);

            charSheet = GameObject.FindGameObjectWithTag("charSheet");
            charSheet.SetActive(false);
        }

       
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Town"); // Start the game when "New Game" it's pressed.
    }

    public void FinishGame() // Finish the game (Not functional at the unity editor).
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu"); // Back to the menu
    }

    public void ResumeGame()
    {
        scroll.SetActive(false);
    }

    public void fadeCharSheet()
    {
        charSheet.SetActive(false);
    }

}
