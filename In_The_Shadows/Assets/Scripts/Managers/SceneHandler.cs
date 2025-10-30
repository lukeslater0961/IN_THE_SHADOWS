using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	public static SceneHandler instance;
	[SerializeField] public string currentScene;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
		currentScene = SceneManager.GetActiveScene().name;
	}

	public void LoadMainMenu()
	{
		StartCoroutine(LoadScene(0));
		GameStateManager.instance.SwitchState(GameStateManager.mainMenuState);
	}

	public void LoadNormalGame()
	{
		GameManager.gameMode = 0;
		GameStateManager.instance.SwitchState(GameStateManager.mapState);
		StartCoroutine(LoadScene(1));
	}	

	public void LoadTestGame()
	{
		GameManager.gameMode = 1;
		SettingsManager.instance.SetValuesForTest();
		GameStateManager.instance.SwitchState(GameStateManager.mapState);
		StartCoroutine(LoadScene(1));
	}

	public void LoadLevel(int index)
	{
		StartCoroutine(LoadScene(index));
	}

	public IEnumerator LoadScene(int index)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);
		while (!asyncLoad.isDone)
			yield return null;
		currentScene = SceneManager.GetActiveScene().name;
		UiManager.instance.ToggleMainMenu();
	}
}
