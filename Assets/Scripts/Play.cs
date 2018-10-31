using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

	// Use this for initialization
	public void OnClick(string name)
    {
        SceneManager.LoadScene(name);
    }
}
