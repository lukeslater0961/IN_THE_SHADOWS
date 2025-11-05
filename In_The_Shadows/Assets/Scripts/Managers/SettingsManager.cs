using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsManager : MonoBehaviour
{
	public static SettingsManager instance;

	[SerializeField]	public LevelBaseScript level1Info;
	[SerializeField]	public LevelBaseScript level2Info;
	[SerializeField]	public LevelBaseScript level3Info;

	void Awake()
	{
		if(!instance)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
		CheckSettings();
	}

	void CheckSettings()
	{
		if (PlayerPrefs.HasKey("level2Lock")){
			SetValues();
		}
		else
			CreateDataSet();
	}

	void CreateDataSet()
	{
		PlayerPrefs.SetInt("level2Lock", 1);
		PlayerPrefs.SetInt("level3Lock", 1);
		PlayerPrefs.SetInt("level1Passed", 0);
		PlayerPrefs.SetInt("level2Passed", 0);
		PlayerPrefs.SetInt("level3Passed", 0);
		SetValues();
	}

	void SetValues()
	{
		level2Info.isLocked = (PlayerPrefs.GetInt("level2Lock") == 1) ? true : false; 
		level3Info.isLocked = (PlayerPrefs.GetInt("level3Lock") == 1) ? true : false; 
		level1Info.passed = (PlayerPrefs.GetInt("level1Passed") == 1) ? true : false; 
		level2Info.passed = (PlayerPrefs.GetInt("level2Passed") == 1) ? true : false;
		level3Info.passed = (PlayerPrefs.GetInt("level3Passed") == 1) ? true : false;
	}

	public void SetSettingsValue(string dataName, int value)
	{
		PlayerPrefs.SetInt(dataName, value);
		switch (dataName)
		{
			case "level2Lock":
				level2Info.isLocked = (value == 1) ? true : false; 
				break;
			case "level3Lock":
				level3Info.isLocked = (value == 1) ? true : false; 
				break;
			case "level1Passed":
				level1Info.passed = (value == 1) ? true : false; 
				break;
			case "level2Passed":
				level2Info.passed = (value == 1) ? true : false; 
				break;
			case "level3Passed":
				level3Info.passed = (value == 1) ? true : false; 
				break;
			default:
				break;
		}
	}

	public void SetValuesForTest()
	{
		level2Info.isLocked = false;
		level3Info.isLocked = false;
	}

	public void EraseData()
	{
		PlayerPrefs.DeleteAll();
		CheckSettings();
		EventSystem.current.SetSelectedGameObject(null);
	}
}
