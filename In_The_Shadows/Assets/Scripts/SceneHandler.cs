using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	public static SceneHandler instance;
	[SerializeField]  string currentScene;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}

    void Start()
    {
		currentScene = SceneManager.GetActiveScene().name;
    }
	
	public void LoadNormalGame()
	{
		GameManager.gameMode = 0;
		StartCoroutine(LoadScene(1));
		GameStateManager.instance.SwitchState(GameStateManager.mapState);
	}	

	public void LoadTestGame()
	{
		GameManager.gameMode = 1;
		StartCoroutine(LoadScene(1));
		GameStateManager.instance.SwitchState(GameStateManager.mapState);
	}

	public IEnumerator LoadScene(int index)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);
		while (!asyncLoad.isDone)
			yield return null;
		currentScene = SceneManager.GetActiveScene().name;
	}
}
