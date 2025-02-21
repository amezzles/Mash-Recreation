using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI soldiersInHelicopterCounterText;
    public TextMeshProUGUI soldiersInHospitalCounterText;
    public TextMeshProUGUI youWin;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI timer;

    private int soldiersInHelicopterCount = 0;
    private int soldiersInHospitalCount = 0;

    private float gameTime = 0f;
    private bool isTimerRunning = false;

    void Start()
    {
        UpdateSoldiersInHelicopterCounterText();
        UpdateSoldiersInHospitalCounterText();
        youWin.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        timer.text = "0.00";
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            gameTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    void UpdateTimerText()
    {
        timer.text = gameTime.ToString("F2");
    }

    public void IncrementSoldiersInHelicopter()
    {
        soldiersInHelicopterCount++;
        UpdateSoldiersInHelicopterCounterText();
    }

    public void IncrementSoldiersInHospital()
    {
        soldiersInHospitalCount += soldiersInHelicopterCount;
        soldiersInHelicopterCount = 0;
        UpdateSoldiersInHospitalCounterText();
        UpdateSoldiersInHelicopterCounterText();    
    }

    void UpdateSoldiersInHelicopterCounterText()
    {
        soldiersInHelicopterCounterText.text = "Soldiers in Helicopter: " + soldiersInHelicopterCount.ToString();
    }

    void UpdateSoldiersInHospitalCounterText()
    {
        soldiersInHospitalCounterText.text = "Soldiers dropped at Hospital: " + soldiersInHospitalCount.ToString();
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        StopTimer();
    }

    public void YouWin()
    {
        youWin.gameObject.SetActive(true);
        StopTimer();
    }

    public int GetSoldiersInHelicopterCount()
    {
        return soldiersInHelicopterCount;
    }
}
