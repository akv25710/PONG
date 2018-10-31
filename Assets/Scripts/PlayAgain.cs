using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {
    
	public void OnClick(string name)
    {
        BallController.score=0;
        BallController.level = 0;
       
        SceneManager.LoadScene(name);

    }
}
