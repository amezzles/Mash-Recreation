using UnityEngine;

public class HelicopterFunction : MonoBehaviour
{
    public GameManager gameManager;

    private int soldiersInHelicopterCount = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check the tag of the collided object
        if (collision.gameObject.CompareTag("Tree"))
        {
            Debug.Log("Tree");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check the tag of the trigger object
        if (other.CompareTag("Hospital"))
        {
            Debug.Log("Hospital");
            soldiersInHelicopterCount = 0;
            gameManager.IncrementSoldiersInHospital();
        }
        else if (other.CompareTag("Soldier"))
        {
            Debug.Log("Soldier");

            if (soldiersInHelicopterCount == 3)
            {
                Debug.Log("Helicopter is full");
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