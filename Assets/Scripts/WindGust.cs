using UnityEngine;

public class WindGust : MonoBehaviour
{
    private Vector2 startingLocation;
    private float windSpeed = 1f;
    private Vector2 windDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingLocation = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        windDirection = new Vector2(Random.Range(-1f, 1f11, Random.Range(-1f, 1f)).normalized;
        transform.position = startingLocation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(windDirection * windSpeed * Time.deltaTime;
    }

    public WindGust CreateWindGust()
    {
        // Create and spawn wind gust object (to be used in GameManager)
        GameObject windGustObject = Instantiate(windGustPrefab, position, rotation);
        return windGustObject.GetComponent<WindGust>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HelicopterMovement helicopter = other.GetComponent<HelicopterMovement>();
            if (helicopter != null)
            {
                helicopter.ApplyWindForce(windDirection * windSpeed);
            }
        }
    }
}
