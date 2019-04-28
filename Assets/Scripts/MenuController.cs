using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    GameObject scroll;

    private void Start()
    {
        scroll = GameObject.FindGameObjectWithTag("menu");
        scroll.SetActive(false);
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
        SceneManager.LoadScene("Menu"); // Start the game when "New Game" it's pushed.
    }

    public void ResumeGame()
    {
        scroll.SetActive(false);
    }


}
