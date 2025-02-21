using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public TextManager textManager;
    public AudioManager audioManager;

    public GameObject windGustPrefab;

    private bool inputEnabled = true;

    private int soldiersInWorld = 5;

    void Start()
    {
        if (textManager == null)
        {
            Debug.LogError("Counters script is not assigned in the GameManager.");
        }

        if (windGustPrefab == null)
        {
            Debug.LogError("WindGust prefab is not assigned in the GameManager.");
        }

        StartCoroutine(SpawnWindGusts());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    public void IncrementSoldiersInHelicopter()
    {
        textManager.IncrementSoldiersInHelicopter();
        audioManager.PlaySoldierPickup();
    }

    public void IncrementSoldiersInHospital()
    {
        if (textManager.GetSoldiersInHelicopterCount() > 0)
        {
            audioManager.PlayHospitalDropOff();
        }

        textManager.IncrementSoldiersInHospital();
    }

    public void GameOver()
    {
        textManager.GameOver();
        audioManager.PlayTreeCollision();

        DisableInput();
        StartCoroutine(ResetGameAfterDelay(3f));
    }

    public void YouWin()
    {
        textManager.YouWin();
        audioManager.PlayYouWin();

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

    private IEnumerator SpawnWindGusts()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);

            
            Vector2 position = new Vector2(Random.Range(-7f, 7f), Random.Range(-4f, 4f));
            Vector2 windDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            // Create and spawn the wind gust
            WindGust.CreateWindGust(windGustPrefab, position, windDirection);
        }
    }
}