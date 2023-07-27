using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private float speed = 10f;
    [SerializeField] private float padding = 1f;
    private float minX, maxX;



    // Start is called before the first frame update
    void Start()
    {
        screenBounds();
        
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        movement(horizontal);
    }

    //private void LateUpdate()
    //{
    //    Vector3 viewPos = transform.position;
    //    viewPos.x = Mathf.Clamp(viewPos.x, rect.anchorMin.x, rect.anchorMax.x);
    //    transform.position = viewPos;
    //}

    void movement(float horizontal)
    {
        float positionX = horizontal * speed * Time.deltaTime;

        float newPosX = Mathf.Clamp(transform.position.x + positionX, minX, maxX);

        transform.position =new Vector2( newPosX, transform.position.y);
    }

    void screenBounds()
    {
        Camera camera = Camera.main;
        minX = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }
}
