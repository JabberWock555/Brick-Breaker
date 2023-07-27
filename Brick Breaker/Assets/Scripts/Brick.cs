using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{
    [SerializeField] private int health = 4;
    private Text health_text;
    
    // Start is called before the first frame update
    void Start()
    {
        health_text = gameObject.GetComponentInChildren<Text>();
        health_text.text = health.ToString();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if(ball != null)
        {
            health--;
            GameManager.score++;
            if(health ==0)
            {
                Destroy(gameObject);
            }
            health_text.text = health.ToString();
        }
    }
}
