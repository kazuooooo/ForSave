using UnityEngine;
using System.Collections;

public struct TestStruct
{
		public string num_a{ get; set; }

		public int num_b;
}

public class StructTest : MonoBehaviour
{
		void Start ()
		{
				TestStruct st = new TestStruct ();
				st.num_b = 10;
				print (st.num_b);

				st.num_a = "20";
				print (st.num_a);
		}
}
