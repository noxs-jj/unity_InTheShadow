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
	public GameObject[]			itemObject;

	private int 		objectNbr = 0;
	private GameObject	lastSelectObject = null;

	void Start () {
		this.itemObject = load_item_with_scene();
		this.objectNbr = get_numberObject ();
		lastSelectObject = this.itemObject[0];
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			findObjectGrabbed ();
		}
		if (1 == this.objectNbr) {
			mouseEvent (this.itemObject[0]);
		} else if (2 == this.objectNbr) {
			mouseEvent (lastSelectObject);
		}
	}
	
	private void findObjectGrabbed () {
		Ray 		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit 	hit;

		if (Physics.Raycast(ray, out hit, 1000)){
			if (hit.collider.tag == "obj0") {
				Debug.Log("clic on obj0");
				lastSelectObject = this.itemObject[0];
			} else if (hit.collider.tag == "obj1") {
				Debug.Log("clic on obj1");
				lastSelectObject = this.itemObject[1];
			}
		}
	}

	private void mouseEvent(GameObject toApply) {
		if (Input.GetMouseButton (0)) {
			if ((Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl))) { // ROTATE VERTICAL
				if (Input.GetAxis("Mouse Y") > 0){
					do_Y_rotate(toApply, (int)Dir.ROTATEUP);
				} else if (Input.GetAxis("Mouse Y") < 0){
					do_Y_rotate(toApply, (int)Dir.ROTATEDOWN);
				}
			} else if ((Input.GetKey (KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) { // TRANSLATE VERTICAL
				if (Input.GetAxis("Mouse Y") < 0){
					do_VERT_translate(toApply, (int)Dir.TRANSUP);
				} else if (Input.GetAxis("Mouse Y") > 0){
					do_VERT_translate(toApply, (int)Dir.TRANSDOWN);
				}/* else if (Input.GetAxis("Mouse X") < 0){
					do_HORI_translate(toApply, (int)Dir.TRANSLEFT);
				} else if (Input.GetAxis("Mouse X") > 0){
					do_HORI_translate(toApply, (int)Dir.TRANSRIGHT);
				}*/	
			} else { // ROTATE HONRIZONTAL
				if (Input.GetAxis("Mouse X") < 0){
					do_X_rotate(toApply, (int)Dir.ROTATELEFT);
				} else if (Input.GetAxis("Mouse X") > 0){
					do_X_rotate(toApply, (int)Dir.ROTATERIGHT);
				}
			}
		}
	}

	private void do_X_rotate(GameObject toApply, int direction) {
		float rotate = (direction == (int)Dir.ROTATELEFT) ? 40.0f : -40.0f;
		toApply.transform.Rotate( new Vector3( 0.0f, rotate, 0.0f) * Time.deltaTime, Space.World );

	}

	private void do_Y_rotate(GameObject toApply, int direction) {
		float rotate = (direction == (int)Dir.ROTATEUP) ? 40.0f : -40.0f;
		toApply.transform.Rotate( new Vector3( rotate, 0.0f, 0.0f) * Time.deltaTime, Space.World );
		
	}

	private void do_VERT_translate(GameObject toApply, int direction) {
		float translate = (direction == (int)Dir.TRANSUP) ? -2.0f : 2.0f;
		toApply.transform.position += new Vector3 (0.0f, translate, 0.0f) * Time.deltaTime;
	}

	private void do_HORI_translate(GameObject toApply, int direction) {
		float translate = (direction == (int)Dir.TRANSLEFT) ? -20.0f : 20.0f;
		toApply.transform.position += new Vector3 (translate, 0.0f, 0.0f) * Time.deltaTime;
	}

	private GameObject[] load_item_with_scene() {
		GameObject[] tabObject = new GameObject[2];
	
		if (null == tabObject)
			return null;
		if (Application.loadedLevelName == "scene_item_teaPot"){
			tabObject[0] = GameObject.Find ("tea_pot_tomove");
			tabObject[1] = null;
		} else if (Application.loadedLevelName == "scene_item4"){
			tabObject[0] = GameObject.Find ("item_4");
			tabObject[1] = null;
		} else if (Application.loadedLevelName == "scene_elephant"){
			tabObject[0] = GameObject.Find ("elephant");
			tabObject[1] = null;
		} else if (Application.loadedLevelName == "scene_globe"){
			tabObject[0] = GameObject.Find ("globe_base");
			tabObject[1] = GameObject.Find ("globe-earth");
		}
		return tabObject;
	}

	private int get_numberObject() {
		if (Application.loadedLevelName == "scene_item_teaPot"
			|| Application.loadedLevelName == "scene_item4"
			|| Application.loadedLevelName == "scene_elephant") {
			return 1;
		} else if (Application.loadedLevelName == "scene_globe") {
			return 2;
		} else {
			return -1;
		}
	}
}
