using UnityEngine;

public class PipeSpwner : MonoBehaviour
{
    public GameObject PipeLevel1;
    public float spawnrate;
    private float timer = 5;
    public float heightOffsetPipe;

    void FixedUpdate()
    {
        if (timer < spawnrate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spwnePipe();
            timer = 0;
        }
    }
    void spwnePipe()
    {
        float highpoint = transform.position.y + heightOffsetPipe;
        float lowpoint = transform.position.y - heightOffsetPipe;
        Instantiate(PipeLevel1, new Vector3(transform.position.x, Random.Range(highpoint, lowpoint), 0), transform.rotation);
    }
}

