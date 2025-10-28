using UnityEngine;
using System.Collections;

[CreateAssetMenu (fileName = "ShadowAnswer[]", menuName = "ShadowAnswer" )]
public class Answer : ScriptableObject
{
	public RenderTexture	renderedAnswer;
	public BitArray			bitMask = new BitArray(64*64);
}
