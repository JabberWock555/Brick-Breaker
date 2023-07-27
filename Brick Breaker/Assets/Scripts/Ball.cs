using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody2D body;
    [SerializeField] private float speed = 500f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.playing)
        {
            Invoke(nameof(motion), 1f);
        }

    }

    private void motion()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        body.AddForce(force.normalized * speed);
    }



}
