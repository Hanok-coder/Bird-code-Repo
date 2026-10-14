using UnityEngine;

public class CherryMovement : MonoBehaviour
{
    public float movespeed = 30;
    public Logicmanager logic;
    public Audiomanager Audio;
    private float deletepoint = -289;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logicmanager>();
        Audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }

    void FixedUpdate()
    {
        transform.position += (Vector3.left * movespeed) * Time.deltaTime;
        if (transform.position.x < deletepoint)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Cherry Added");
            Audio.PlaySFX(Audio.Cherry);
            logic.addScore();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Pipe"))
        {
            //Debug.Log("Cherry Destroyed");
            Destroy(gameObject);
        }

    }

}
