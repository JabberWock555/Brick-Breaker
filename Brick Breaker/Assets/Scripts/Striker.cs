using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 30f;
    private Vector2 direction;
    private float maxBounceAngle = 75f;
    
    void Start()
    {

    }

    void Update()
    {
        setDirection();

    }

    private void FixedUpdate()
    {
        movement(direction);
    }

    void setDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal > 0.1f)
        {
            direction = Vector2.right;
        }
        else if (horizontal < -0.1f)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    void movement(Vector2 direction_)
    {
        if (direction != Vector2.zero)
        {
            rb.AddForce(direction_ * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D ball = collision.gameObject.GetComponent<Rigidbody2D>();

        if( ball != null)
        {
            Vector3 strikerPos = transform.position;
            Vector2 contactPoints = collision.GetContact(0).point;

            float offset = strikerPos.x - contactPoints.x;
            float width = collision.otherCollider.bounds.size.x /2;

            float currAngle = Vector2.SignedAngle(Vector2.up, ball.velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.velocity = rotation * Vector2.up * ball.velocity.magnitude;
        }
    }

}
