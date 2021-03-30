using UnityEngine;
using System.Collections;

public class CollisSound : MonoBehaviour {
	public AudioClip[] myClips;
	public AudioSource audioSource;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter()
	{
		if(gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1.2f)
		{
			int i = Random.Range(0, myClips.Length);
			audioSource.PlayOneShot(myClips[i]);
		}
	}
}
