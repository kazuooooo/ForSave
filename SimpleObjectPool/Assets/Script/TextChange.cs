using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
		//textのゲームオブジェクト
		private GameObject textObj;

		void Start ()
		{
				//textのゲームオブジェクトを取得
				textObj = gameObject.transform.FindChild ("Text").gameObject;
		}

		public void showEndText ()
		{
				//テキストにEndを入れる
				textObj.GetComponent<Text> ().text = "End";
		}

		public void showAnimationText ()
		{
				//テキストにAnimationの文字を入れる
				textObj.GetComponent<Text> ().text = "Animation";
		}
}
