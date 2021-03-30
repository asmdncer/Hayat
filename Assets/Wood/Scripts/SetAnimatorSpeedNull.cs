using UnityEngine;
using System.Collections;

public class SetAnimatorSpeedNull : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Animator>().speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
