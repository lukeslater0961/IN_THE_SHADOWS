using UnityEngine;
using System.Collections.Generic;
using System;

public class MapManager : MonoBehaviour
{
	public static MapManager	instance;
	public static int			currentLevelIndex;
	public static event Action	OnMapInitialized;

	[SerializeField] private List<GameObject> levels;

	void Awake()
	{
		if (instance == null){
			instance = this;
		}
		else
			Destroy(gameObject);
	}

	void Start()
	{
		currentLevelIndex = 0;
	}

	public  void InitialiseLevelState()
	{
		if (GameManager.instance.firstLoad)
		{
			bool lockState = (GameManager.gameMode == 1) ? false : true;
			foreach(GameObject gb in levels)
			{
				if(gb.name == "Level1"){
					gb.GetComponent<LevelPlaceHolder>().levelInfo.isLocked = false;
				}
				else
					gb.GetComponent<LevelPlaceHolder>().levelInfo.isLocked = lockState;
				gb.GetComponent<LevelPlaceHolder>().levelInfo.passed = false;
			}
		}
		OnMapInitialized?.Invoke();
	}
}
