using UnityEngine;

public class ShadowChecker : MonoBehaviour
{
	public static ShadowChecker			instance;

	[SerializeField]	Answer			levelAnswer;
	[SerializeField]	RenderTexture	renderTexture;
	[SerializeField]	byte[]			byteMask;

	void Awake()
	{
		if (instance == null){
			instance = this;
		}
		else
			Destroy(gameObject);
	}

	public void CheckShadow()
	{
		float invalidPixels = 0f;
		GetTextureValues();
		for (int i = 0; i < byteMask.Length; i++)
		{
			if ((byteMask[i] ^ levelAnswer.byteMask[i]) != 0)
				invalidPixels += 1f;
		}
		Debug.Log(invalidPixels / byteMask.Length);
		if ((invalidPixels / byteMask.Length) > levelAnswer.threshold)
		{
			Debug.Log("not same");
			return; 
		}
		else
		{
			Debug.Log("same");
			LevelManager.instance.LevelPassed();
		}
	}

	void GetTextureValues()
	{
		RenderTexture currentRT = RenderTexture.active;
		RenderTexture.active = renderTexture;

		Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
		tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
		tex.Apply();
		byteMask = new byte[(renderTexture.width / 8) * renderTexture.height];
		byteMask = ReadPixelFromTexture(byteMask, tex);
		RenderTexture.active = currentRT;
	}

	byte[] ReadPixelFromTexture(byte[] byteMask, Texture2D tex)
	{
		for (int y = 0 ; y < renderTexture.height ; y++)
		{
			for (int x = 0 ; x < renderTexture.width ; x++)
			{
				float gray = tex.GetPixel(x, y).grayscale;
				int byteIndex = y * (renderTexture.width / 8) + (x / 8);
				int bitPosition = 7 - (x % 8);

				if (gray == 0f)
					byteMask[byteIndex] |= (byte)(1 << bitPosition);
			}
		}
		return byteMask;
	}
}
