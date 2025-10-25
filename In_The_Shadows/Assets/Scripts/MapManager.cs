using UnityEngine;
using System.Collections.Generic;

public class MapManager : MonoBehaviour
{
	[SerializeField] private List<GameObject> levels;
	public static MapManager instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	public  void InitialiseLevelState()
	{
		foreach(GameObject gb in levels)
		{
			
		}
	}
}
