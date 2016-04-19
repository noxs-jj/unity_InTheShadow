using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	private GameObject[]	tabColliderObject;
	private sphCollider[]	tabColliderScript;
	private bool[]			tabIsActive;
	
	void Start () {
		int i = 0;
		
		this.tabColliderObject = GameObject.FindGameObjectsWithTag ("sphere_collider");
		this.tabColliderScript = new sphCollider[this.tabColliderObject.Length];
		foreach (GameObject sphereObject in this.tabColliderObject) {
			this.tabColliderScript[i] = this.tabColliderObject[i].GetComponent<sphCollider>();
		}
		this.tabIsActive = new bool[this.tabColliderObject.Length];
		foreach (bool isActive in this.tabIsActive) {
			isActive = false;
		}
	}
	
	void Update () {
		keyboard_event ();
		check_collider_win ();
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
