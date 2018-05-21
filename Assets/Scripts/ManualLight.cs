using UnityEngine;
using System.Collections;

public enum ManualObject{
	solar,flight,blight
}

public class ManualLight : MonoBehaviour {

	public ManualObject type;

	public bool active = false;
	bool on = true;

	public float speed = 10f;

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;

	public float limitRotationX = 0f;
	float limitX = 0f;
	public float limitRotationY = 0f;
	float limitY = 0f;
	/*public float limitRotationZ = 0f;
	float limitZ = 0f;*/

	float xR = 0f;
	float yR = 0f;
	float zR = 0f;

	//Vector3 initEuler;
	// Use this for initialization
	void Start () {
		xR = transform.localEulerAngles.x;
		yR = transform.localEulerAngles.y;
		zR = transform.localEulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {

		if(!active) return;

		if(Input.GetKey(up)){
			if(limitRotationX == 0 || limitX < limitRotationX){
				float r = speed*Time.deltaTime;
				limitX += r;
				xR += r;
			}
		}else if(Input.GetKey(down)){
			if(limitRotationX == 0 || limitX > -limitRotationX){
				float r = -speed*Time.deltaTime;
				limitX += r;
				xR += r;
			}
		}

		if(Input.GetKey(left)){
			if(limitRotationY == 0 || limitY < limitRotationY){
				float r = speed*Time.deltaTime;
				limitY += r;
				yR += r;
			}
		}else if(Input.GetKey(right)){
			if(limitRotationY == 0 || limitY > -limitRotationY){
				float r = -speed*Time.deltaTime;
				limitY += r;
				yR += r;
			}
		}

		transform.localRotation = Quaternion.identity;

		transform.Rotate(xR,yR,zR);

	}

	public void Activate(){
		switch(type){
		case ManualObject.solar:
			break;
		case ManualObject.flight:
			on = !on;
			for(int i = 0; i < transform.childCount; i++) transform.GetChild(i).gameObject.SetActive(on);
			if(on) FindObjectOfType<StatusText>().SetText("передний прожектор включен");
			else FindObjectOfType<StatusText>().SetText("передний прожектор выключен");
			break;
		case ManualObject.blight:
			on = !on;
			for(int i = 0; i < transform.childCount; i++) transform.GetChild(i).gameObject.SetActive(on);
			if(on) FindObjectOfType<StatusText>().SetText("задний прожектор включен");
			else FindObjectOfType<StatusText>().SetText("задний прожектор выключен");
			break;
		}
	}
}
