using UnityEngine;
using TMPro;

public class LevelPlaceHolder : MonoBehaviour
{
	[SerializeField]	LevelBaseScript levelInfo;
	[SerializeField]	TMP_Text			levelText;
	[SerializeField]	GameObject			border;

	public bool		isLocked;


	void Start()
	{
		if (gameObject.name != "Level1")
			MapManager.OnMapInitialized += CheckLock;
	}

	void OnDestroy()
	{
		if (gameObject.name != "Level1")
			MapManager.OnMapInitialized -= CheckLock;
	}


	void OnTriggerEnter(Collider other)
	{
		if (isLocked) return;
		MapManager.currentLevelIndex = levelInfo.levelSceneIndex;
		levelText.gameObject.SetActive(true);
	}

	void OnTriggerExit(Collider other)
	{
		if (isLocked) return;
		MapManager.currentLevelIndex = 0;
		levelText.gameObject.SetActive(false);
	
	}

	public void CheckLock()
	{
		if (isLocked){
			border.SetActive(true);
		}
		else
			border.SetActive(false);
	}
}
