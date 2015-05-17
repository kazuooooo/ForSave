using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBreakTest : MonoBehaviour
{
		void Start ()
		{
				gameObject.GetComponent<Text> ().text = "1行目\n2行目";
		}
}
