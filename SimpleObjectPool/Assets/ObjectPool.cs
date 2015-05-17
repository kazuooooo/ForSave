using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
		//ObjectPoolのインスタンス
		private static ObjectPool _instance;
		// シングルトン
		public static ObjectPool instance {
				get {
						// シーン上からオブジェクトプールを取得して返す
						_instance = FindObjectOfType<ObjectPool> ();
						return _instance;
				}
		}
		//玉のprefab
		public GameObject ballPrefab;
		//Makerオブジェクト
		public GameObject maker;
		//玉の初期位置
		Vector3 originalPos;
		//玉の初期角度
		Quaternion originalRotation;
		private List<GameObject> pooledGameObjects;
		//ボールの番号
		private int ballNum = 0;

		void Start ()
		{
				originalPos = maker.transform.position;
				originalRotation = maker.transform.rotation;
				//リストを生成
				pooledGameObjects = new List<GameObject> ();
		}
		//これがInstantiateの代わりを果たす
		public GameObject getBall ()
		{
				//poolされたゲームオブジェクトで使用出来るもの(非アクティブ)がある場合
				//位置、角度を初期化、オブジェクトを有効化して返す
				foreach (GameObject obj in pooledGameObjects) {
						if (obj.activeInHierarchy == false) {
								//位置を初期化
								obj.transform.position = originalPos;
								//角度を設定
								obj.transform.rotation = originalRotation;
								//アクティブにする
								obj.SetActive (true);
								//オブジェクトを返す
								return obj;
						}
				}

				//使用できるものが無かった場合
				//新たに生成して、リストに追加して返す
				GameObject newObj = (GameObject)Instantiate (ballPrefab, originalPos, originalRotation);
				//ボールに番号をつける
				newObj.gameObject.name = "ball" + ballNum.ToString ();
				ballNum++;
				//リストに追加
				pooledGameObjects.Add (newObj);
				//オブジェクトを返す
				return newObj;
		}
		//これがDestroyの代わりを果たすMake
		public void releaseBall (GameObject obj)
		{
				obj.SetActive (false);
		}
}
