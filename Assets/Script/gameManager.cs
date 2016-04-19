using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	private GameObject[]	tabColliderObject;
	private sphCollider[]	tabColliderScript;
	private bool[]			tabIsActive;
	
	void Start () {
		this.tabColliderObject = GameObject.FindGameObjectsWithTag ("sphere_collider");

		int i = 0;
		int tabLen = this.tabColliderObject.Length;

		Debug.Log("this.tabColliderObject.Length " + tabLen.ToString());
		this.tabColliderScript = new sphCollider[tabLen];
		foreach (GameObject sphereObject in this.tabColliderObject) {
			this.tabColliderScript[i] = sphereObject.GetComponent<sphCollider>();
		}
		this.tabIsActive = new bool[tabLen];
		while (i < tabLen) {
			this.tabIsActive[i] = false;
			i++;
		}
	}
	
	void Update () {
		keyboard_event ();
		if (true == check_collider_win ()) {
			Debug.Log("WIN");
		} else {
			Debug.Log("try");
		}
	}
	
	public void	setActive(int id){
		this.tabIsActive [id] = true;
	}
	
	public void	setInactive(int id) {
		this.tabIsActive [id] = false;
	}

	private bool check_collider_win(){
		bool isAllTrue = true;

		foreach (bool isactive in this.tabIsActive) {
			if (isactive == false) {
				isAllTrue = false;
			}
		}
		return isAllTrue;
	}
	
	private void keyboard_event(){
		if (Input.GetKeyDown (KeyCode.S)) {
			debug_printSphereTabId();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	
	private void debug_printSphereTabId() {
		foreach(sphCollider scriptObj in this.tabColliderScript) {
			Debug.Log("sphereID = " + scriptObj.get_idCurrent());
		}
	}
}
