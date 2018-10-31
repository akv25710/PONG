using UnityEngine.UI;
using UnityEngine;

public class ScoreCardManager : MonoBehaviour {
    [SerializeField]
    private Text Score;
    [SerializeField]
    private Text HighScoreDisplay;

    private static int highScore = 0; 
   
    void Start () {
        int score = BallController.score;
        Score.text = score.ToString();

        if (PlayerPrefs.HasKey("highestScore"))
        {
            highScore = PlayerPrefs.GetInt("highestScore");
        }
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highestScore",highScore);
        }
        
        HighScoreDisplay.text = highScore.ToString();
    }

}
