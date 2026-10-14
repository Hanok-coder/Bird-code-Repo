using System.Collections;
using UnityEngine;

public class BirdScript : MonoBehaviour

{
    public Rigidbody2D myRigidbody;
    public float flapstrength;
    public bool BirdisAlive = true;
    public float dashstrength;
    public Logicmanager logic;
    private float dashDuration = 0.2f;
    private float originalGravityScale = 19f;
    public Audiomanager Audio;
    private float deletepoint = -101;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logicmanager>();
        Audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audiomanager>();
    }

    void Update()
    {
        if ( transform.position.y < deletepoint)
        {
            Destroy(gameObject);
            logic.gameOver();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && BirdisAlive)
        {
            myRigidbody.velocity = Vector2.up * flapstrength;
            Audio.PlaySFX(Audio.Fly);
        }
        else if (Input.GetKeyDown(KeyCode.D) && BirdisAlive)
        {
            myRigidbody.velocity = Vector2.right * dashstrength;
            Audio.PlaySFX(Audio.Fly);
            StartCoroutine(DisableGravity());
        }
        else if (Input.GetKeyDown(KeyCode.A) && BirdisAlive)
        {
            myRigidbody.velocity = Vector2.left * dashstrength;
            Audio.PlaySFX(Audio.Fly);
            StartCoroutine(DisableGravity());
        }
    }

    private IEnumerator DisableGravity()
    {
        myRigidbody.gravityScale = 0f;
        yield return new WaitForSeconds(dashDuration);
        myRigidbody.gravityScale = originalGravityScale;
        myRigidbody.velocity = Vector2.up;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        BirdisAlive = false;
        Audio.PlaySFX(Audio.Death);
        GetComponent<Collider2D>().enabled = false;

    }

}

//originalGravityScale = myRigidbody.gravityScale;
/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public float dashStrength;
    public Logicmanager logic;

    // Dash settings
    public float dashDuration = 0.2f;
    public float dashCooldown = 0.5f;
    public float cameraFOVBoost = 10f;

    private float originalGravityScale;
    private float cooldownTimer = 0f;
    private int facingDirection = 1;
    private bool isDashing = false;
    private Camera cam;
    private float baseFOV;
    private SpriteRenderer sprite;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logicmanager>();
        originalGravityScale = myRigidbody.gravityScale;
        cam = Camera.main;
        baseFOV = cam.fieldOfView;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        // Track facing direction
        if (Input.GetAxisRaw("Horizontal") > 0) facingDirection = 1;
        else if (Input.GetAxisRaw("Horizontal") < 0) facingDirection = -1;

        if (!isDashing)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.velocity = Vector2.up * flapStrength;
            }
            else if (Input.GetKeyDown(KeyCode.KeypadEnter) && cooldownTimer <= 0f)
            {
                cooldownTimer = dashCooldown;
                StartCoroutine(Dash());
            }
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        myRigidbody.gravityScale = 0f;

        // Camera FOV boost
        cam.fieldOfView = baseFOV + cameraFOVBoost;

        // Squash & stretch
        if (sprite != null)
            transform.localScale = new Vector3(1.3f, 0.7f, 1f);

        float elapsed = 0f;
        while (elapsed < dashDuration)
        {
            myRigidbody.velocity = Vector2.right * facingDirection * dashStrength;
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Restore
        myRigidbody.gravityScale = originalGravityScale;
        cam.fieldOfView = baseFOV;
        if (sprite != null)
            transform.localScale = Vector3.one;
        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
    }
}   
 */



