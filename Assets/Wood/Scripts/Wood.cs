using UnityEngine;
using System.Collections;

public class Wood : MonoBehaviour {
	public GameObject _Position, _treeUpChild, _treeUpParent;
	public GameObject ForwardPlayer;
	public float HP = 100, SpeedFall = 2;
	public GameObject timber1, timber2;
	public MeshRenderer _MeshWood;
	public float TimerDestroy = 3;
	private float tim;
	private int goTim;
	public AudioSource _AudioSource;
	public AudioClip _ClipBreak;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(goTim == 0)
			if(HP <= 0)
		{
			GetComponent<Collider>().enabled = false;
			_treeUpChild.transform.parent = _treeUpParent.transform;
			_AudioSource.PlayOneShot(_ClipBreak);
			goTim = 1;
		}
		if(timber1 != null || timber2 != null)
			if(goTim == 1)
		{
			tim += Time.deltaTime;
			_treeUpParent.transform.rotation = Quaternion.Euler(_treeUpParent.transform.eulerAngles.x + SpeedFall * Time.deltaTime, _treeUpParent.transform.eulerAngles.y, _treeUpParent.transform.eulerAngles.z);
			if(tim > TimerDestroy)
			{
				
				_MeshWood.enabled = false;
				if(timber1 != null)
				{
					timber1.SetActive(true);
					timber1.transform.parent = null;
				}
				if(timber2 != null)
				{
					timber2.SetActive(true);
					timber2.transform.parent = null;
				}
			}
		}
	}
	
	public void DestroyWood () {
		GetComponent<Collider>().enabled = false;
		_treeUpChild.transform.parent = _treeUpParent.transform;
		_AudioSource.PlayOneShot(_ClipBreak);
		goTim = 1;
	}
}
