using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	[SerializeField] public static int gameMode;
	[SerializeField]public 	bool isInMenu;
	
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
		isInMenu = false;
	}

	public void ToggleFullScreen()
	{
		Screen.fullScreen = !Screen.fullScreen;
		EventSystem.current.SetSelectedGameObject(null);
	}

	public void QuitGame()
	{
		Application.Quit();
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	public IEnumerator WaitForSeconds(float time)
	{
		yield return new WaitForSeconds(time);
	}
}
