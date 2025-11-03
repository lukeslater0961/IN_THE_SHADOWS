using UnityEngine;
using System.Collections;

[CreateAssetMenu (fileName = "ShadowAnswer[]", menuName = "ShadowAnswer" )]
public class Answer : ScriptableObject
{
	public RenderTexture	renderedAnswer;
	public byte[]			byteMask;
	public float			threshold;
}
