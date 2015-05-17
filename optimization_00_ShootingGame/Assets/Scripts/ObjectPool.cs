using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
		//ObjectPool型のインスタンスを定義
		//変数はprivate
		private static ObjectPool _instance;
		//シングルトン
		//メソッドはpublic getterを定義
		public static ObjectPool instance {
				get { 
						if (_instance == null) {
						
								//シーン上から取得
								_instance = FindObjectOfType<ObjectPool> ();

								//シーン上に無いとき
								if (_instance == null) {
										//ゲームオブジェクトを作成してObjectPoolコンポーネントをアタッチ
										_instance = new GameObject ("ObjectPool").AddComponent<ObjectPool> ();
								}
						}
						//ObjectPoolインスタンスを返す
						return _instance;
				}
		}
		//ゲームオブジェクトのDictionary(数字をkeyにしてGameObjectのリストを保持)
		//いろんなprefabを登録しておくリスト
		private Dictionary<int,List<GameObject>> pooledGameObjects = new Dictionary<int,List<GameObject>> ();
		//ゲーブオブジェクトをpooledGameObjectsから取得する。必要であれば新たに生成する
		public GameObject GetGameObject (GameObject prefab, Vector2 position, Quaternion rotation)
		{
				//プレハブのインスタンスIDをkeyとする
				int key = prefab.GetInstanceID ();

				//Dictionalyにkeyが存在しなければ作成する(prefabを登録しておく)
				if (pooledGameObjects.ContainsKey (key) == false) {
						pooledGameObjects.Add (key, new List<GameObject> ());
				}

				//keyから対象のGameObjectのprefabを取得
				List<GameObject> gameObjects = pooledGameObjects [key];

				GameObject go = null;

				//使用出来るゲームオブジェクトがあれば
				for (int i = 0; i < gameObjects.Count; i++) {
						go = gameObjects [i];

						//現在非アクティブであれば
						if (go.activeInHierarchy == false) {
								//位置を設定
								go.transform.position = position;
								//角度を設定
								go.transform.rotation = rotation;
								//これから使用するのでアクティブにする
								go.SetActive (true);

								//ゲームオブジェクトを返す
								return go;
						}
				}

				//使用出来るものが無ければ新たに生成する
				go = (GameObject)Instantiate (prefab, position, rotation);

				//ObjectPoolゲームオブジェクトの子要素にする
				go.transform.parent = transform;

				//リストに追加
				gameObjects.Add (go);

				//ゲームオブジェクトを返す
				return go;


		}
		//ゲームオブジェクトを非アクティブにする。こうすることで再利用可能状態にする
		public void ReleaseGameObject (GameObject go)
		{
				print ("ReleaseObject");
				go.SetActive (false);
		}
}
