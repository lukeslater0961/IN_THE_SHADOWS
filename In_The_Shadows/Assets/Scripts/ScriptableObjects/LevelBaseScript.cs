using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu (fileName = "LevelPlaceHolder", menuName = "level" )]
public class LevelBaseScript : ScriptableObject
{
	public int	levelSceneIndex;
	public bool	isLocked;
	public bool passed;
}
