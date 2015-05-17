using UnityEngine;
using System.Collections;

public class Maker_A : MonoBehaviour
{
		//玉のprefab
		public GameObject ball;
		//射出の
		public float pace;
		// Use this for initialization
		void Start ()
		{
				StartCoroutine (MakeBall ());
		}
		// Update is called once per frame
		void Update ()
		{
	
		}
		//ボールを生成するメソッド
		IEnumerator MakeBall ()
		{
				while (true) {
						yield return new WaitForSeconds (pace);
						//Instantiate (ball, gameObject.transform.position, Quaternion.identity);
						ObjectPool.instance.getBall ();
				}
		}
}
