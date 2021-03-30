using UnityEngine;
using System.Collections;

public class Axe_Particle_Sound : MonoBehaviour {
	public AudioSource _AudioSource;
	public AudioClip clipAxe;
	public string NameTagWood;
	public float Damage = 20;
	public GameObject SpawnParticle;
	public GameObject _Particle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == NameTagWood)
		{
			Instantiate(_Particle, SpawnParticle.transform.position, Quaternion.identity);
			_AudioSource.PlayOneShot(clipAxe);
			other.gameObject.GetComponent<Wood>().HP -= Damage;
		}
	}
}
