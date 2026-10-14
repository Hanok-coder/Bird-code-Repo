using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float movespeed = 10;

    void FixedUpdate()
    {
        transform.position += (Vector3.left * movespeed) * Time.deltaTime;
    }
}
