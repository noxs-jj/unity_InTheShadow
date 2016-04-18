using UnityEngine;
using System.Collections;

enum Dir : int {
	ROTATEUP,
	ROTATEDOWN,
	ROTATELEFT,
	ROTATERIGHT,
	TRANSUP,
	TRANSDOWN,
	TRANSLEFT,
	TRANSRIGHT
}

public class moveMouse : MonoBehaviour {

	public GameObject	itemObject;

	void Start () {
		this.itemObject = GameObject.Find ("logo-4");
	}
	
	void Update () {
		mouseEvent ();
	}

	private void mouseEvent(){
		if (Input.GetMouseButton (0)) {
			if ((Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl))) { // ROTATE VERTICAL
				if (Input.GetAxis("Mouse Y") > 0){
					do_Y_rotate((int)Dir.ROTATEUP);
				} else if (Input.GetAxis("Mouse Y") < 0){
					do_Y_rotate((int)Dir.ROTATEDOWN);
				}
			} else if ((Input.GetKey (KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) { // TRANSLATE VERTICAL
				if (Input.GetAxis("Mouse Y") < 0){
					do_VERT_translate((int)Dir.TRANSUP);
				} else if (Input.GetAxis("Mouse Y") > 0){
					do_VERT_translate((int)Dir.TRANSDOWN);
				}
			} else { // ROTATE HONRIZONTAL
				if (Input.GetAxis("Mouse X") < 0){
					do_X_rotate((int)Dir.ROTATELEFT);
				} else if (Input.GetAxis("Mouse X") > 0){
					Debug.Log("MOUSE AXE RIGHT");
				}
			}
		}
	}

	private void do_X_rotate(int direction){
		float rotate = (direction == (int)Dir.ROTATELEFT) ? 40.0f : -40.0f;
		this.itemObject.transform.Rotate( new Vector3( 0.0f, rotate, 0.0f) * Time.deltaTime );

	}

	private void do_Y_rotate(int direction){
		float rotate = (direction == (int)Dir.ROTATEUP) ? 40.0f : -40.0f;
		this.itemObject.transform.Rotate( new Vector3( rotate, 0.0f, 0.0f) * Time.deltaTime );
		
	}

	private void do_VERT_translate(int direction) {
		float translate = (direction == (int)Dir.TRANSUP) ? -20.0f : 20.0f;
		this.itemObject.transform.position += new Vector3 (0.0f, translate, 0.0f) * Time.deltaTime;
	}
}
