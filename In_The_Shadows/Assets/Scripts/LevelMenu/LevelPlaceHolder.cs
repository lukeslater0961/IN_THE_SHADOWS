using UnityEngine;
using TMPro;

public class LevelPlaceHolder : MonoBehaviour
{
	[SerializeField]	public LevelBaseScript levelInfo;
	[SerializeField]	TMP_Text			levelText;
	[SerializeField]	GameObject			border;

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
		if (levelInfo.isLocked) return;
		if (!levelInfo.passed || GameManager.gameMode == 1)
			MapManager.currentLevelIndex = levelInfo.levelSceneIndex;
		levelText.gameObject.SetActive(true);
	}

	void OnTriggerExit(Collider other)
	{
		if (levelInfo.isLocked) return;
		MapManager.currentLevelIndex = 0;
		levelText.gameObject.SetActive(false);
	
	}

	public void CheckLock()
	{
		if (levelInfo.isLocked){
			border.SetActive(true);
		}
		else
			border.SetActive(false);
	}
}
