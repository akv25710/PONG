using UnityEngine;

public class SpawnPowers : MonoBehaviour {

    private int score;
    public GameObject powerUps;

    public Sprite FastPaddle;
    public Sprite SlowBall;
    public Sprite IncreaseBallSize;
    public Sprite IncreasePaddleLength;

    private int i;
    public static int choice;
    public static bool isInstantiated = false;

    private static int prevScore = -1;

    private void Update()
    {
        score = BallController.score;

        if (score % 20 == 0 )
        {

            Debug.Log(PowersManager.powerList);
            if (PowersManager.powerList.Count == 0) return;

            if (!isInstantiated && score > prevScore)
            {
                prevScore = score;

                i = Random.Range(0, PowersManager.powerList.Count );
                
                Instantiate(powerUps, new Vector2(Random.Range(-11.0f, 11.0f), -9.5f), Quaternion.identity);
                isInstantiated = true;

                Debug.Log(i);
                
                if (PowersManager.powerList[i] == 0)
                {
                    powerUps.GetComponentInChildren<SpriteRenderer>().sprite = FastPaddle;
                    
                }
                else if (PowersManager.powerList[i] == 1)
                {
                    powerUps.GetComponentInChildren<SpriteRenderer>().sprite = SlowBall;
                }
                else if (PowersManager.powerList[i] == 2)
                {
                    powerUps.GetComponentInChildren<SpriteRenderer>().sprite = IncreaseBallSize;
                }
                else if (PowersManager.powerList[i] == 3)
                {
                    powerUps.GetComponentInChildren<SpriteRenderer>().sprite = IncreasePaddleLength;
                }
                choice = PowersManager.powerList[i];
            }
            
        }
        
    }

}
