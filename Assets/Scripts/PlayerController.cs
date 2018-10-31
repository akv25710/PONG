using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 0.1f ;
    private bool isPower = false;

    public GameObject powerUp;

    public GameObject ball;
    private Transform ballTransform;
    

    void Start () {
        ballTransform = ball.GetComponent<Transform>();
        transform.position = new Vector2(0, -9.5f);
    }

	void Update () {
        int score =  BallController.score;
        if (isPower && score % 10 == 0 && score % 20 != 0 )
        {
            ResetPlayerPowers();
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            if (Mathf.Abs(transform.position.x) < 13.6f || touchDeltaPosition.x < 0 && transform.position.x > 13.6f || 
                                                           touchDeltaPosition.x > 0 && transform.position.x < -13.6f)
            {
                if (Mathf.Abs(touchDeltaPosition.x) > 100)
                    touchDeltaPosition.x = touchDeltaPosition.x > 0? 100.0f : -100.0f;
                transform.Translate(touchDeltaPosition.x * 10 * speed * Time.deltaTime, 0, 0);
            }
        }
         
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Power")
        {
            int  i = SpawnPowers.choice;
            if (i == 0)
            {
                speed += 0.1f;
            }
            else if (i == 1)
            {
                BallController.speed -= 2;
            }
            else if (i == 2)
            {
                ballTransform.localScale = new Vector2(2, 2);
            }
            else if(i==3)
            {
                transform.localScale = new Vector3(8, 0.8f,0);
            }
           
            if (SpawnPowers.isInstantiated == true)
            {

                Destroy(collision.gameObject);
                SpawnPowers.isInstantiated = false;
                
            }
            isPower = true;
        }
    }


    private void ResetPlayerPowers()
    {
        isPower = false;
        speed = 0.1f;
        transform.localScale = new Vector2(5, 0.8f);
        ballTransform.localScale = new Vector2(1, 1);
        BallController.speed = 10.0f;
    }


    
}
