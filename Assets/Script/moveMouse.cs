using UnityEngine;
using System.Collections;

public class moveMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mouseEvent ();
	}

	private void mouseEvent(){
		if (Input.GetMouseButton (0)) {
			if ((Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl))) { // ROTATE VERTICAL
				if (Input.GetAxis("Mouse Y") > 0){
					Debug.Log("MOUSE AXE UP");
				} else if (Input.GetAxis("Mouse Y") < 0){
					Debug.Log("MOUSE AXE DOWN");
				}
			} else if ((Input.GetKey (KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) { // TRANSLATE VERTICAL
				if (Input.GetAxis("Mouse X") < 0){
					Debug.Log("MOUSE AXE LEFT");
				} else if (Input.GetAxis("Mouse X") > 0){
					Debug.Log("MOUSE AXE RIGHT");
				}
			} else { // ROTATE HONRIZONTAL
				if (Input.GetAxis("Mouse X") < 0){
					Debug.Log("MOUSE AXE LEFT");
				} else if (Input.GetAxis("Mouse X") > 0){
					Debug.Log("MOUSE AXE RIGHT");
				}
			}
		}
	}
}
