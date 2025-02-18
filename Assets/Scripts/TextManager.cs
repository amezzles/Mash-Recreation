using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI soldiersInHelicopterCounterText;
    public TextMeshProUGUI soldiersInHospitalCounterText;
    public TextMeshProUGUI youWin;
    public TextMeshProUGUI gameOver;

    private int soldiersInHelicopterCount = 0;
    private int soldiersInHospitalCount = 0;

    void Start()
    {
        UpdateSoldiersInHelicopterCounterText();
        UpdateSoldiersInHospitalCounterText();
        youWin.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
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
    }

    public void YouWin()
    {
        youWin.gameObject.SetActive(true);
    }
}
