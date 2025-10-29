using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField]	LevelBaseScript	nextLevel;
	[SerializeField]	LevelBaseScript	levelInfo;
	public static LevelManager instance;

	void Awake()
	{
		if (instance == null){
			instance = this;
		}
		else
			Destroy(gameObject);
	}

	public void LevelPassed()
	{
		nextLevel.isLocked = false;
		levelInfo.passed = true;
		if (GameManager.gameMode == 0){
			SceneHandler.instance.LoadNormalGame();
		}
		else
			SceneHandler.instance.LoadTestGame();
	}
}
