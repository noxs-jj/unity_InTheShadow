using UnityEngine;
using System.Collections;

public class logoIntro : MonoBehaviour {
	private float 	i = 0.0f;
	private bool	isGoUp = true;
	
	void Update () {
		if (false == this.isGoUp) {
			gameObject.transform.position -= new Vector3 (0.0f, this.i, 0.0f) * Time.deltaTime;
			gameObject.transform.position -= new Vector3 (this.i, 0.0f, 0.0f) * Time.deltaTime;
			this.i -= 0.3f;
		} else if (true == this.isGoUp) {
			this.i += 0.3f;
			gameObject.transform.position += new Vector3 (0.0f, this.i, 0.0f) * Time.deltaTime;
			gameObject.transform.position += new Vector3 (this.i, 0.0f, 0.0f) * Time.deltaTime;
		}
		if (this.i >= 20.0f) {
			this.isGoUp = false;
		} else if (this.i <= -20.0f) {
			this.isGoUp = true;
		}
	}
}
