using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	[SerializeField] public static int gameMode;
	[SerializeField]public 	bool isInMenu;
	public bool		firstLoad;
	
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
		firstLoad = true;
	}

	public void QuitGame()
	{
		Application.Quit();
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
}
