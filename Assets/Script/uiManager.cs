using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uiManager : MonoBehaviour {
	private GameObject	buttonClassicModeObject;
	private GameObject	buttonTestModeObject;
	private GameObject	buttonBackIntroObject;
	private GameObject	menuInterfaceEscapeObject;
	private GameObject	panelLevelSelectObject;
	private GameObject	maskTeaPotObject;
	private GameObject	maskElephantObject;
	private GameObject	maskGlobeObject;
	private GameObject	maskTBonusObject;
	private bool		isMenuDraw = true;
	
	void Start () {
		this.buttonClassicModeObject = GameObject.Find ("button_classic_mode");
		this.buttonTestModeObject = GameObject.Find ("button_test_mode");
		this.buttonBackIntroObject = GameObject.Find ("button_back_to_intro");
		this.menuInterfaceEscapeObject = GameObject.Find ("menuInterface_escape");
		this.panelLevelSelectObject = GameObject.Find ("panel_level_select");
		this.maskTeaPotObject = GameObject.Find ("mask_image_teaPot");
		this.maskElephantObject = GameObject.Find ("mask_image_elephant");
		this.maskGlobeObject = GameObject.Find ("mask_image_globe");
		this.maskTBonusObject = GameObject.Find ("mask_image_bonus");
		this.panelLevelSelectObject.SetActive (false);
		this.menuInterfaceEscapeObject.SetActive (true);
	}
	
	void Update () {
		keyboard_event ();
	}
	
	public void activateTestPanelSelect(){ this.panelLevelSelectObject.SetActive (true); }
	public void desactivateTestPanelSelect(){ this.panelLevelSelectObject.SetActive (false); }
	public void activateClassicPanelSelect(){ this.panelLevelSelectObject.SetActive (true); }
	public void desactivateClassicPanelSelect(){ this.panelLevelSelectObject.SetActive (false); }
	
	public void launchLevelTeaPot(){ Application.LoadLevel ("scene_item_teaPot"); }
	public void launchLevelElephant(){ Application.LoadLevel ("scene_elephant"); }
	public void launchLevelGlobe(){ Application.LoadLevel ("scene_globe"); }
	public void launchLevelBonus(){ Application.LoadLevel ("scene_bonus"); }
	public void launchIntroStart(){ Application.LoadLevel ("intro_start"); }
	
	private void keyboard_event(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			this.isMenuDraw = (this.isMenuDraw == true) ? false : true;
			this.menuInterfaceEscapeObject.SetActive(this.isMenuDraw);
		}
	}
}
