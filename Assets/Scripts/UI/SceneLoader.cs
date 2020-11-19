using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	private int currentSceneIndex;

	private void Start()
	{
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentSceneIndex == 0)
		{
			Cursor.visible = true;
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("Cancel") && currentSceneIndex != 0)
		{
			currentSceneIndex = 0;
			SceneManager.LoadScene(currentSceneIndex);
		}
	}

	public void LoadNextScene()
	{
		if (++currentSceneIndex >= SceneManager.sceneCountInBuildSettings)
		{
			currentSceneIndex = 0;
		}
		SceneManager.LoadScene(currentSceneIndex);
	}

	public void LoadCurrentScene()
	{
		SceneManager.LoadScene(currentSceneIndex);
	}

	public void GameQuit()
	{
		Application.Quit();
	}
}
