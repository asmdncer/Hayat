using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {
	public string NameTagCamera;
	public bool CollisNoYes = false;
	public int[] NumberWoodPart;
	public GameObject[] ObjectPart;
	public GameObject[] ObjectPartWhite;
	public int i = 0;
	public bool Builded = false;
	public int dpCount = 0;
	public AudioSource _AudioSource;
	public AudioClip ClipBulid;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Builded == false)
		if(i == ObjectPart.Length)
		{
			Builded = true;
		}
	
	}

	public void BuildH (int NumbPart) {
		if(NumbPart >= NumberWoodPart[i])
		{
			ObjectPart[i].SetActive(true);
			ObjectPartWhite[i].SetActive(false);
			_AudioSource.PlayOneShot(ClipBulid);
			if(i < NumberWoodPart.Length - 1)
			ObjectPartWhite[i+1].SetActive(true);
			i++;
		}
	}

	public void DPcoun (int dpC) {
		dpCount += dpC;
		if(dpCount == NumberWoodPart[i])
		{
			ObjectPart[i].SetActive(true);
			ObjectPartWhite[i].SetActive(false);
			_AudioSource.PlayOneShot(ClipBulid);
			if(i < NumberWoodPart.Length - 1)
				ObjectPartWhite[i+1].SetActive(true);
			i++;
			dpCount = 0;
		}
		 if(dpCount > NumberWoodPart[i])
		{
			ObjectPart[i].SetActive(true);
			ObjectPartWhite[i].SetActive(false);
			_AudioSource.PlayOneShot(ClipBulid);
			if(i < NumberWoodPart.Length - 1)
				ObjectPartWhite[i+1].SetActive(true);
			i++;
			dpCount = 0;
		}
	}
}
