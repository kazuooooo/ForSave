using UnityEngine;

public class Bullet : MonoBehaviour
{
		// 弾のスピード
		public int speed = 10;

		void OnEnable ()
		{
				rigidbody2D.velocity = transform.up.normalized * speed;
		}
		// 弾が何らかのトリガーに当たった時に呼び出される
		void OnTriggerExit2D (Collider2D other)
		{
				// 弾の削除
				ObjectPool.instance.ReleaseGameObject (gameObject);
		}
}