using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Transform aim;
    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private GameObject pointPrefab;
    public GameObject[] points;
    public GameObject[] balls;
    [SerializeField] private int numberofballs = 50;
    [SerializeField] private int numberofPoints = 20;
    [SerializeField] private float speed = 30f;
    private bool shooting = false;
    private Vector2 direction;
    private float maxBounceAngle = 75f;
    private float aimAngle = 0f;
    private float offsetAngle = -90f;
    private float shootDelay = 0.1f;
    public static int ballsDestroyed = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        points = new GameObject[numberofPoints];
        balls = new GameObject[numberofballs];
    }

    void Update()
    {
        if (!shooting)
        {
            HandleAim();
        }
        CalculateTrajectory();
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shooting = true;
            StartCoroutine( ShootBall());
            
        }
        if(ballsDestroyed  == numberofballs)
        {
            shooting =false;
            ballsDestroyed = 0;
        }
    }

    void CalculateTrajectory()
    {
        // Remove old points
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] != null)
            {
                Destroy(points[i]);
            }
        }

        if (!shooting)
        {
            // Calculate and instantiate new points
            for (int i = 0; i < points.Length; i++)
            {
                Vector2 pointPosition = PointPosition(i * 0.05f);
                points[i] = Instantiate(pointPrefab, pointPosition, Quaternion.identity, gameObject.transform);

                // Calculate scale factor based on the index (i)
                float scale = 10f - (float)i * 5 / (points.Length - 1);
                points[i].transform.localScale = new Vector3(scale, scale, 1f);
            }
        }
    }

    void HandleAim()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = mousePos - transform.position;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        aimAngle += offsetAngle;

        // Ensure aimAngle is within [-90, 90] degrees
        aimAngle = Mathf.Clamp(aimAngle, -maxBounceAngle, maxBounceAngle);

        

        // Apply the new aimAngle to the aim's local rotation
        aim.localRotation = Quaternion.Euler(0f, 0f, aimAngle);

        // Store the direction for shooting
        direction = aim.up;
    }


    IEnumerator ShootBall()
    {
        Vector2 direction = aim.up;
        for (int i  =0; i < balls.Length; i++)
        {
            SoundManager.Instance.Play(SoundEvents.BallShoot);
            balls[i] = Instantiate(BallPrefab, transform.position, Quaternion.identity, gameObject.transform);

            if (direction != Vector2.zero)
            {
                Rigidbody2D rb = balls[i].GetComponent<Rigidbody2D>();
                rb.AddForce(direction * speed * 70f);
            }
            yield return new WaitForSeconds(shootDelay);
        }
        
    }

    Vector2 PointPosition(float t)
    {
        Vector2 currPointPos = (Vector2)transform.position + (speed * t * direction.normalized);
        return currPointPos;
    }

    public void enableStriker()
    {
        gameObject.SetActive(true);
    }

    public void disableStriker()
    {
        if (!GameManager.playing)
        {
            gameObject.SetActive(false);
            for (int i = 0; i < balls.Length; i++)
            {
                if (balls[i] != null)
                {
                    Destroy(balls[i]);
                }
            }
        }
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 direction_ = new Vector2(horizontal, 0f).normalized;

        if (direction_ != Vector2.zero)
        {
            rb.AddForce(direction_ * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D ball = collision.gameObject.GetComponent<Rigidbody2D>();

        if (ball != null)
        {
            SoundManager.Instance.Play(SoundEvents.BallHit);
        }
    }
}
