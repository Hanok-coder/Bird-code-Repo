using UnityEngine;

public class CherrySpwner : MonoBehaviour
{
    public GameObject Cherry;
    public float spawnrate;
    private float timer = 5;
    public float heightOffsetCherry;

    void FixedUpdate()
    {
        if (timer < spawnrate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spwneCherry();
            timer = 0;
        }
    }
    void spwneCherry()
    {
        {
            float highpointY = transform.position.y + heightOffsetCherry;
            float lowpointY = transform.position.y - heightOffsetCherry;
            float highpointX = transform.position.x; //+ heightOffsetCherry;
            float lowpointX = transform.position.x - heightOffsetCherry;
            Instantiate(Cherry, new Vector3(Random.Range(highpointX, lowpointX), Random.Range(highpointY, lowpointY), 0), transform.rotation);
        }
    }
}