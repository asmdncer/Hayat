using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {

	public float destroyTime;
	private float tim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tim += Time.deltaTime;
		if(tim > destroyTime)
		{
			Destroy(gameObject);
		}
	}
}
