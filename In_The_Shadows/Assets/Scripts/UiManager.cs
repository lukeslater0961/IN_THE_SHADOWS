using UnityEngine;

public class UiManager : MonoBehaviour
{
	public static UiManager instance;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}
}
