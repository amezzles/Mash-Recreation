using UnityEngine;

public class WindGust : MonoBehaviour
{
    private float windSpeed = 2f;
    private Vector2 windDirection;

    void Start()
    {
        windSpeed = Random.Range(1f, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.right * windSpeed * Time.deltaTime, Space.Self);
    }

    public static WindGust CreateWindGust(GameObject windGustPrefab, Vector2 position, Vector2 windDirection)
    {
        float angle = Mathf.Atan2(windDirection.y, windDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        GameObject windGustObject = Instantiate(windGustPrefab, position, rotation);

        WindGust windGust = windGustObject.GetComponent<WindGust>();

        if (windGust != null)
        {
            windGust.SetWindDirection(windDirection);
        }

        return windGust;
    }

    public void SetWindDirection(Vector2 direction)
    {
        windDirection = direction.normalized;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("WindGust OnTriggerEnter2D with " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Collided with Helicopter");
            HelicopterMovement helicopter = other.GetComponent<HelicopterMovement>();
            if (helicopter != null)
            {
                helicopter.ApplyWindForce(windDirection * windSpeed);
            }
        }
    }
}