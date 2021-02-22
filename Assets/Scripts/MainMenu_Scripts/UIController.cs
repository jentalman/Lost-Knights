using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    [SerializeField] private GameManager difficulty;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DifficultyButton(int difficulty)
    {
        this.difficulty.difficulty = difficulty;
    }
}
