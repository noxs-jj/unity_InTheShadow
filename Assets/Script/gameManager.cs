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
		
		//Debug.Log("this.tabColliderObject.Length " + tabLen.ToString());
		this.tabColliderScript = new sphCollider[tabLen];
		foreach (GameObject sphereObject in this.tabColliderObject) {
			this.tabColliderScript[i] = sphereObject.GetComponent<sphCollider>();
			//Debug.Log(this.tabColliderScript[i].get_idCurrent());
		}
		this.tabIsActive = new bool[tabLen];
		while (i < tabLen) {
			this.tabIsActive[i] = false;
			i++;
		}
	}
	
	void Update () {
		keyboard_event ();
		if (true == check_collider_win() && Application.loadedLevelName != "intro_start") {
			Debug.Log("WIN WIN WIN");
			loadNextLevel();
		}
	}

	public void	setActive(int id){
		this.tabIsActive [id] = true;
		//Debug.Log("setActive id: " + id.ToString());
	}
	
	public void	setInactive(int id) {
		this.tabIsActive [id] = false;
		//Debug.Log("setInactive id: " + id.ToString());
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
	
	private void loadNextLevel(){
		if (Application.loadedLevelName == "intro_start"){
			sphCollider.instance.reset_static_id();
			Application.LoadLevel ("scene_item_teaPot");
		} else if (Application.loadedLevelName == "scene_item_teaPot"){
			sphCollider.instance.reset_static_id();
			Application.LoadLevel ("scene_elephant");
		} else if (Application.loadedLevelName == "scene_elephant"){
			sphCollider.instance.reset_static_id();
			Application.LoadLevel ("scene_globe");
		} else if (Application.loadedLevelName == "scene_globe"){
			sphCollider.instance.reset_static_id();
			Application.LoadLevel ("scene_bonus");
		} else if (Application.loadedLevelName == "scene_bonus"){
			sphCollider.instance.reset_static_id();
			Application.LoadLevel ("intro_start");
		}
	}
}
