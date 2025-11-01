using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField]	LevelBaseScript	nextLevel;
	[SerializeField]	LevelBaseScript	levelInfo;
	[SerializeField]	GameObject		obj;
	public static LevelManager instance;

	void Awake()
	{
		if (instance == null){
			instance = this;
		}
		else
			Destroy(gameObject);
		SetObjRotation();
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
	
	public void SetObjRotation()
	{
		float rotation = Random.Range(50, 300);
		Debug.Log($"rotatiing on {rotation}");
		obj.transform.Rotate(Vector3.up, rotation, Space.World);
	}
}
