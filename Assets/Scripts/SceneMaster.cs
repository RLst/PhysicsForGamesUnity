using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour {

	void Start()
	{
		//This needs to exist between scenes
		DontDestroyOnLoad(this);
	}

	public void TransitionScene(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
