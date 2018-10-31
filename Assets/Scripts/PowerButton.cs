using UnityEngine.SceneManagement;
using UnityEngine;

public class PowerButton : MonoBehaviour {

	public void OnClick(string name)
    {
        SceneManager.LoadScene(name);
       
    }
}
