using UnityEngine;

public class HelicopterFunction : MonoBehaviour
{
    public GameManager gameManager;

    private int soldiersInHelicopterCount = 0;
    private int soldiersDroppedAtHospital = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check the tag of the collided object
        if (collision.gameObject.CompareTag("Tree"))
        {
            gameManager.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check the tag of the trigger object
        if (other.CompareTag("Hospital"))
        {
            soldiersDroppedAtHospital += soldiersInHelicopterCount;

            soldiersInHelicopterCount = 0;
            gameManager.IncrementSoldiersInHospital();

            if (soldiersDroppedAtHospital == gameManager.GetSoldiersInWorld())
            {
                gameManager.YouWin();
            }
        }
        else if (other.CompareTag("Soldier"))
        {
            if (soldiersInHelicopterCount == 3)
            {
                return;
            }
            else
            {
                soldiersInHelicopterCount++;
                gameManager.IncrementSoldiersInHelicopter();
                Destroy(other.gameObject);
            }
        }
    }
}