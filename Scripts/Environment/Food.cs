using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	void OnCollisionEnter(Collision collision){

		if(collision.collider.gameObject.tag == "Dog"){

			collision.collider.gameObject.transform.parent.gameObject.GetComponent<Dog>().iScore++;
			gameObject.transform.position = new Vector3(Random.Range(-150,150),1.4f,Random.Range(-150,150));
		}
}
}
