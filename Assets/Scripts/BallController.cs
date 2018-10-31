using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BallController : MonoBehaviour {

    public static float speed = 10.0f ;
    private  Rigidbody2D ball;
    public static int level = 0;
    public static int score = 0;

    public Text scoreText;
    public Text levelText;

    [SerializeField]
    private new AudioSource audio;

    
    void  Start() {
        bool isPlaying = GameAudio.isPlaying;
        if (isPlaying)
        {
            audio.Play();
        }
        ball = GetComponent<Rigidbody2D>();
        InitializeBall();
    }

 


    void Update() {

        scoreText.text = score.ToString();
        levelText.text = (level + 1).ToString();

        MaintainVelocity();

        if (GameOver() || level == 5)
        {
            SceneManager.LoadScene("EndScene");
        }

        if (NextLevel())
        {
         
           level++;
           if (level < 5) {
                SceneManager.LoadScene("GameScene");
            }
        }

    }

    

    void InitializeBall(){

        float initialX = Random.Range(-0.5f, 0.5f);
        ball.velocity = new Vector2(initialX, -1) * speed;
       
    }

    float HitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleLength)
    {
        return (ballPos.x - paddlePos.x) / paddleLength;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            float x = HitFactor(transform.position, collision.transform.position, collision.transform.localScale.x);
            ball.velocity = new Vector2(x, 1) * speed;
        }
        if(collision.gameObject.tag == "Collectable")
        {
            
            Destroy(collision.gameObject);
            ReverseBall();
            score++;
        }
    }

    bool GameOver()
    {
        return ball.position.y < -10;
    }

    void ReverseBall()
    {
        Vector2 dir = ball.velocity;
        ball.velocity = -dir;
    }

    void MaintainVelocity()
    {
        if (Mathf.Abs(ball.velocity.y) < speed)
        {
            if (ball.velocity.y < 0)
            {
                ball.velocity = new Vector2(ball.velocity.x, -speed);
            }
            else
            {
                ball.velocity = new Vector2(ball.velocity.x, speed);
            }
        }
    }

    bool NextLevel()
    {
        int[] total = { 200, 500, 900, 1400, 2000 };
        return score == total[level];
    }
}
