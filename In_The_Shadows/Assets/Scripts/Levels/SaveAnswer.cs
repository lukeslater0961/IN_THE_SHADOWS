using UnityEngine;
using UnityEditor;
using System.Collections;

public class SaveAnswer : MonoBehaviour
{
		public static SaveAnswer instance;
		[SerializeField]	RenderTexture	renderTexture;
		[SerializeField]	byte[]		byteMask;


		[SerializeField]
		[TextArea(1, 1)] 
		private string folderPath; 

		[SerializeField]
		[TextArea(1, 1)] 
		private string fileName;

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
			newAnswer.byteMask =  GetTextureValues(renderTexture);
			string assetPath = folderPath + fileName + ".asset";

			System.IO.Directory.CreateDirectory(folderPath);

			AssetDatabase.CreateAsset(newAnswer, assetPath);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

		byte[] GetTextureValues(RenderTexture renderTexture)
		{
			RenderTexture currentRT = RenderTexture.active;
			RenderTexture.active = renderTexture;

			Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
			tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
			tex.Apply();
			byteMask = new byte[(renderTexture.width / 8) * renderTexture.height];
			byteMask = ReadPixelFromTexture(byteMask, tex);
			RenderTexture.active = currentRT;
			return(byteMask);
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

					if (gray < 0.5f)
						byteMask[byteIndex] |= (byte)(1 << bitPosition);
				}
			}
			return byteMask;
		}
}
