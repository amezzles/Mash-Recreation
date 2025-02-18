using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public TextManager textManager;
    private bool inputEnabled = true; // Flag to control input

    private int soldiersInWorld = 5;

    void Start()
    {
        if (textManager == null)
        {
            Debug.LogError("Counters script is not assigned in the GameManager.");
        }
    }

    public void IncrementSoldiersInHelicopter()
    {
        textManager.IncrementSoldiersInHelicopter();
    }

    public void IncrementSoldiersInHospital()
    {
        textManager.IncrementSoldiersInHospital();
    }

    public void GameOver()
    {
        textManager.GameOver();
        DisableInput();
        StartCoroutine(ResetGameAfterDelay(3f));
    }

    public void YouWin()
    {
        textManager.YouWin();
        DisableInput();
        StartCoroutine(ResetGameAfterDelay(3f));
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator ResetGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetGame();
    }

    public int GetSoldiersInWorld()
    {
        return soldiersInWorld;
    }

    public bool IsInputEnabled()
    {
        return inputEnabled;
    }

    private void DisableInput()
    {
        inputEnabled = false;
    }

    private void EnableInput()
    {
        inputEnabled = true;
    }
}