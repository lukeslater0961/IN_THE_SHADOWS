using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[SerializeField]	LevelBaseScript	nextLevel;
	[SerializeField]	LevelBaseScript	levelInfo;
	[SerializeField]	GameObject		obj1;
	[SerializeField]	GameObject		obj2;

	private				DragHandler		dragHandler;

	public static LevelManager instance;

	void Awake()
	{
		if (instance == null){
			instance = this;
		}
		else
			Destroy(gameObject);
		SetObjRotation();
	}

	void Start()
	{
		dragHandler = new DragHandler();
		SetInputRules();
	}

	void SetInputRules()
	{
		switch (levelInfo.levelName)
		{
			case "level1":
				InputHandler.instance.SetRules(new Level1Rules(dragHandler));
				break;
			case "level2":
				InputHandler.instance.SetRules(new Level2Rules(dragHandler));
				break;
			case "level3":
				InputHandler.instance.SetRules(new Level3Rules(dragHandler));
				break;
			default:
				break;
		}
	}

	public void LevelPassed()
	{
		if (nextLevel)
			SettingsManager.instance.SetSettingsValue(nextLevel.levelName + "Lock", 0);
		SettingsManager.instance.SetSettingsValue(levelInfo.levelName + "Passed", 1);

		GameStateManager.instance.SwitchState(GameStateManager.successState);
	}
	
	public void SetObjRotation()
	{
		float rotationX = Random.Range(50, 300);
		float rotationY = Random.Range(50, 300);

		Quaternion randomRotation = Quaternion.Euler(rotationY, rotationX, 0f);
		switch (levelInfo.levelName)
		{
			case "level1":
				obj1.transform.rotation = Quaternion.Euler(90f, randomRotation.x, 0f);
				break;
			case "level2":
				obj1.transform.rotation = randomRotation;
				break;
			case "level3":
				obj1.transform.rotation = randomRotation;
				obj2.transform.rotation = randomRotation;
				break;
			default:
				break;
		}
	}
}
