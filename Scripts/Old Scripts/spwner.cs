using UnityEngine;

public class spwner : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public float spawnrate;
    private int i = 0;
    private float timer = 5;
    public float heightOffsetPipe;
    public float heightOffsetCherry;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnrate < i)
        {
            spwneCherry();
            i = 0;
        }
        else if (timer < spawnrate)
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
        Instantiate(prefab1, new Vector3(transform.position.x, Random.Range(highpoint, lowpoint), 0), transform.rotation);
        i = i + 1;
        Debug.Log(i);
    }

    void spwneCherry()
    {
        {
            float highpoint = transform.position.y + heightOffsetCherry;
            float lowpoint = transform.position.y - heightOffsetCherry;
            Instantiate(prefab2, new Vector3(transform.position.x, Random.Range(highpoint, lowpoint), 0), transform.rotation);
        }
    }


}

