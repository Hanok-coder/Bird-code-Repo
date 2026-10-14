using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryScripts : MonoBehaviour
{
    public float movespeed = 30;
    public float deleteCherry = -289;
    public Logicmanager logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logicmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * movespeed) * Time.deltaTime;

        if (transform.position.x < deleteCherry)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        logic.addScore();
        Destroy(gameObject);
    }
}
