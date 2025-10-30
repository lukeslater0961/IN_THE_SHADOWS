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
		OnMapInitialized?.Invoke();
	}
}
