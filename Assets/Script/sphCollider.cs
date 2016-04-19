using UnityEngine;
using System.Collections;

public class sphCollider : MonoBehaviour {

	public static int	idSphere = 0;

	private GameObject	managerObject;
	private gameManager managerScript;
	private int			idCurrent;


	void Start () {
		this.idCurrent = idSphere;
		idSphere++;
		this.managerObject = GameObject.Find ("game_manager_object ");
		this.managerScript = this.managerObject.GetComponent<gameManager> ();
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider obj){
		this.managerScript.setActive (this.idCurrent);
	}

	void OnTriggerExit(Collider obj){
		this.managerScript.setInactive (this.idCurrent);
	}
}
