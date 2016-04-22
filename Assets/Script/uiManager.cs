using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uiManager : MonoBehaviour {
	private GameObject		buttonClassicModeObject;
	private GameObject		buttonTestModeObject;
	private GameObject		buttonBackIntroObject;
	private GameObject		menuInterfaceEscapeObject;
	private GameObject		panelLevelSelectObject;
	private GameObject		winnerInterfaceObject;
	private GameObject[]	tabSphereObjects;
	private GameObject[]	tabBarObjects;
	private GameObject		gameManagerObject;
	private gameManager		gameManagerScript;
	private bool			isMenuDraw;
	private bool			isSoluceDraw = false;
	
	void Start () {
		this.buttonClassicModeObject = GameObject.Find ("button_classic_mode");
		this.buttonTestModeObject = GameObject.Find ("button_test_mode");
		this.buttonBackIntroObject = GameObject.Find ("button_back_to_intro");
		this.menuInterfaceEscapeObject = GameObject.Find ("menuInterface_escape");
		this.panelLevelSelectObject = GameObject.Find ("panel_level_select");
		this.winnerInterfaceObject = GameObject.Find ("winnerInterface_group");
		this.gameManagerObject = GameObject.Find ("game_manager_object");
		this.gameManagerScript = this.gameManagerObject.GetComponent<gameManager> ();
		this.tabBarObjects = GameObject.FindGameObjectsWithTag ("barre_impact_collider");
		this.tabSphereObjects = GameObject.FindGameObjectsWithTag ("sphere_collider");
		this.panelLevelSelectObject.SetActive (false);
		this.menuInterfaceEscapeObject.SetActive (true);
		this.winnerInterfaceObject.SetActive(false);
		soluce_draw();
		if (Application.loadedLevelName == "intro_start") {
			this.isMenuDraw = true;
			this.menuInterfaceEscapeObject.SetActive(true);

		} else {
			this.isMenuDraw = false;
			this.menuInterfaceEscapeObject.SetActive(this.isMenuDraw);
		}
	}
	
	void Update () {
		keyboard_event ();
		drawPause ();
	}
	
	public void activateTestPanelSelect(){
		sphCollider.instance.reset_static_id();
		this.panelLevelSelectObject.SetActive (true);
	}
	public void desactivateTestPanelSelect(){
		sphCollider.instance.reset_static_id();
		this.panelLevelSelectObject.SetActive (false);
	}
	public void activateClassicPanelSelect(){ 		this.panelLevelSelectObject.SetActive (true); }
	public void desactivateClassicPanelSelect(){ 	this.panelLevelSelectObject.SetActive (false); }

	public void launchLevelTeaPot(){ 	loadLEveLResetStaticSphe ("scene_item_teaPot"); }
	public void launchLevelElephant(){ 	loadLEveLResetStaticSphe ("scene_elephant"); }
	public void launchLevelGlobe(){ 	loadLEveLResetStaticSphe ("scene_globe"); }
	public void launchLevelBonus(){ 	loadLEveLResetStaticSphe ("scene_bonus"); }
	public void launchLevelBonus1(){ 	loadLEveLResetStaticSphe ("scene_bonus1"); }
	public void launchIntroStart(){ 	loadLEveLResetStaticSphe ("intro_start"); }

	public void retry(){
		sphCollider.instance.reset_static_id();
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void loadNextLevel(){
		if (Application.loadedLevelName == "intro_start"){ 				loadLEveLResetStaticSphe ("scene_item_teaPot"); } 
		else if (Application.loadedLevelName == "scene_item_teaPot"){	loadLEveLResetStaticSphe ("scene_elephant"); }
		else if (Application.loadedLevelName == "scene_elephant"){ 		loadLEveLResetStaticSphe ("scene_globe"); }
		else if (Application.loadedLevelName == "scene_globe"){ 		loadLEveLResetStaticSphe ("scene_bonus"); }
		else if (Application.loadedLevelName == "scene_bonus"){ 		loadLEveLResetStaticSphe ("scene_bonus1"); }
		else if (Application.loadedLevelName == "scene_bonus1"){ 		loadLEveLResetStaticSphe ("intro_start"); }
	}

	private void loadLEveLResetStaticSphe(string levelName){
		sphCollider.instance.reset_static_id();
		Application.LoadLevel (levelName);
	}

	private void drawPause(){
		if (true == this.gameManagerScript.isWin) {
			this.winnerInterfaceObject.SetActive(true);
		}
	}

	private void keyboard_event(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Application.loadedLevelName == "intro_start") {
				this.menuInterfaceEscapeObject.SetActive(true);
				this.isMenuDraw = true;
			} else {
				this.isMenuDraw = (this.isMenuDraw == true) ? false : true;
				this.menuInterfaceEscapeObject.SetActive(this.isMenuDraw);
				Time.timeScale = (this.isMenuDraw == true) ? 0.0f : 1.0f;
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			this.isSoluceDraw = (this.isSoluceDraw == true) ? false : true;
			soluce_draw();
		}
	}

	private void soluce_draw(){
		if (true == this.isSoluceDraw) {
			foreach (GameObject obj in this.tabBarObjects) {
				obj.GetComponent<MeshRenderer> ().enabled = true;
			}
			foreach (GameObject obj in this.tabSphereObjects) {
				obj.GetComponent<MeshRenderer> ().enabled = true;
			}
		} else {
			foreach (GameObject obj in this.tabBarObjects) {
				obj.GetComponent<MeshRenderer> ().enabled = false;
			}
			foreach (GameObject obj in this.tabSphereObjects) {
				obj.GetComponent<MeshRenderer> ().enabled = false;
			}
		}
	}
}
