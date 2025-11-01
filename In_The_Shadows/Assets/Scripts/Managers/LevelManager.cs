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
		SetInputRules();
	}

	void SetInputRules()
	{
		switch (levelInfo.levelName)
		{
			case "level1":
				InputHandler.instance.SetRules(new Level1Rules());
				break;
			case "level2":
				InputHandler.instance.SetRules(new Level2Rules());
				break;
			case "level3":
				InputHandler.instance.SetRules(new Level3Rules());
				break;
			default:
				break;
		}
	}

	public void LevelPassed()
	{
		SettingsManager.instance.SetSettingsValue(nextLevel.levelName + "Lock", 0);
		SettingsManager.instance.SetSettingsValue(levelInfo.levelName + "Passed", 1);

		if (GameManager.gameMode == 0){
			SceneHandler.instance.LoadNormalGame();
		}
		else
			SceneHandler.instance.LoadTestGame();
	}
}
