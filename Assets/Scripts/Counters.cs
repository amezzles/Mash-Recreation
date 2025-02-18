using UnityEngine;
using TMPro;

public class Counters : MonoBehaviour
{
    public TextMeshProUGUI soldiersInHelicopterCounterText;
    public TextMeshProUGUI soldiersInHospitalCounterText;
    private int soldiersInHelicopterCount = 0;
    private int soldiersInHospitalCount = 0;

    void Start()
    {
        UpdateSoldiersInHelicopterCounterText();
        UpdateSoldiersInHospitalCounterText();
    }

    public void IncrementSoldiersInHelicopter()
    {
        soldiersInHelicopterCount++;
        UpdateSoldiersInHelicopterCounterText();
    }

    public void IncrementSoldiersInHospital()
    {
        soldiersInHospitalCount++;
        UpdateSoldiersInHospitalCounterText();
    }

    void UpdateSoldiersInHelicopterCounterText()
    {
        soldiersInHelicopterCounterText.text = "Soldiers in Helicopter: " + soldiersInHelicopterCount.ToString();
    }

    void UpdateSoldiersInHospitalCounterText()
    {
        soldiersInHospitalCounterText.text = "Soldiers dropped at Hospital: " + soldiersInHospitalCount.ToString();
    }
}
