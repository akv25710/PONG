using UnityEngine.SceneManagement;
using UnityEngine;

public class Back : MonoBehaviour {

	public void OnClick(string name)
    {
        SceneManager.LoadScene(name);
    }
}
