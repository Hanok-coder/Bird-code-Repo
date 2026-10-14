using UnityEngine;

public class PipeMovemet : MonoBehaviour
{
    public float movespeed = 30;
    private float deletepoint = -289;
    
    void FixedUpdate()
    {
        transform.position += (Vector3.left * movespeed) * Time.deltaTime;
        if (transform.position.x < deletepoint)
        {
            Destroy(gameObject);
        }
    }

}
