using UnityEngine;
using System.Collections.Generic;

public class MapManager : MonoBehaviour
{
	public static MapManager instance;

	[SerializeField] private List<GameObject> levels;

	void Awake()
	{
		if (instance == null){
			instance = this;
		}
		else
			Destroy(gameObject);
	}

	public  void InitialiseLevelState()
	{
		bool lockState = (GameManager.gameMode == 1) ? false : true;
		foreach(GameObject gb in levels)
		{
			if(gb.name == "Level1"){
				gb.GetComponent<LevelPlaceHolder>().isLocked = false;
			}
			else
				gb.GetComponent<LevelPlaceHolder>().isLocked = lockState;
		}
	}
}
