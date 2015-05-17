using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour
{
		void OnCollisionEnter (Collision col)
		{
				print ("col");
				//Destroy (col.gameObject);
				ObjectPool.instance.releaseBall (col.gameObject);
		}
}
