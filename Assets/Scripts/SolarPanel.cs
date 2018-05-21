using UnityEngine;
using System.Collections;

public class SolarPanel : MonoBehaviour {

	SpaceShip ship;
	// Use this for initialization
	void Start () {
		ship = GetComponentInParent<SpaceShip>();
		StartCoroutine(CheckLight());
	}

	IEnumerator CheckLight(){
		for(;;){
			yield return new WaitForSeconds(5);

			float add = 0f;

			foreach(Star s in ship.stars){

				Vector3 forward = transform.TransformDirection(Vector3.forward);
				Vector3 toOther = s.transform.position - transform.position;

				float dot = Mathf.Abs(Vector3.Dot(forward,toOther.normalized));
				float starLight = s.pointLight.intensity;

				//Debug.Log(dot * starLight);

				add += (dot * starLight);
			}

			if(add > 0) ship.ChangeEnergy(add);//
		}
	}

	void OnCollisionEnter(Collision c){
		if(c.gameObject.tag == "Asteroid"){
			transform.parent = null;
			Rigidbody rb = gameObject.AddComponent<Rigidbody>();
			rb.useGravity = false;
			rb.angularDrag = 0;
			rb.mass = 0.1f;
			Destroy(this);
		}
	}
}
