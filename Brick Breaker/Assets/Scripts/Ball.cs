using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("death"))
        {
            Destroy(gameObject);
            Striker.ballsDestroyed++;
        }
    }



}
