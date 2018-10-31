using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour {

	public void OnClick(string name)
    {
        BallController.score = 0;
        SceneManager.LoadScene(name);
    }
}
