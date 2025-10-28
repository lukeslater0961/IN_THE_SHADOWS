using UnityEngine;
using UnityEditor;
using System.Collections;

public class SaveAnswer : MonoBehaviour
{
		public static SaveAnswer instance;
		[SerializeField]	RenderTexture	renderTexture;
		[SerializeField]	byte[]		byteMask;

		void Awake()
		{
			if (instance == null){
				instance = this;
			}
			else
				Destroy(gameObject);
		}
		
		public void SetValues()
		{
			Answer newAnswer = ScriptableObject.CreateInstance<Answer>();

			newAnswer.renderedAnswer = renderTexture;
			GetTextureValues(renderTexture);
			string folderPath = "Assets/Scripts/Levels/Level1/";
			string assetPath = folderPath + "level1Answer" + ".asset";

			System.IO.Directory.CreateDirectory(folderPath);

			AssetDatabase.CreateAsset(newAnswer, assetPath);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

		void GetTextureValues(RenderTexture renderTexture)
		{
			RenderTexture currentRT = RenderTexture.active;
			RenderTexture.active = renderTexture;

			Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
			tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
			tex.Apply();
			byteMask = new byte[renderTexture.height * 8];
			for (int y = 0 ; y < renderTexture.height ; y++)
			{
				for (int x = 0 ; x < renderTexture.width ; x += 8)
					byteMask[y] = SetBitArray(tex, ref x, y);
			}
			for (int i = 0; i < byteMask.Length; i++)
				Debug.Log(byteMask[i]);
		}

		byte SetBitArray(Texture2D tex, ref int x, int y)
		{
			byte bit = 0;
			float grayScaleValue = 0f;
			for (int bx = 0; bx < 8; bx++)
			{
				grayScaleValue += tex.GetPixel(x + bx, y).grayscale;
				if (grayScaleValue >= 0.5)
					bit |= (byte)(1 << (7 - bx));
			}
			return bit;
		}
}
