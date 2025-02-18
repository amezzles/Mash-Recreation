using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Counters countersManager;

    void Start()
    {
        if (countersManager == null)
        {
            Debug.LogError("Counters script is not assigned in the GameManager.");
        }
    }

    public void IncrementSoldiersInHelicopter()
    {
        countersManager.IncrementSoldiersInHelicopter();
    }

    public void IncrementSoldiersInHospital()
    {
        countersManager.IncrementSoldiersInHospital();
    }
}