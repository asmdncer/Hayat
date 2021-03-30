using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Axe_Wood_House : MonoBehaviour {
	public GameObject Player, TimberEmulation, TimberEmulation2, AXE;
	public string NameTagWood, NameTagTimber, NameTagHouse, NameVarAxeAnimator, NameVarAxeUpDownAnimator, NameTagAxe;
	public string NameAnimationAxe;
	public Animator _AnimatorAxe;
	public RaycastHit hit;
	public float DistanceRay = 1;
	public Text  WoodInform;
	public Image Inform, WoodNeeded;
	private int hack = 0, _Wood = 0;
	public Collider ColliderAxe;
	private Wood wood;
	public Vector3 LocalPosAxe;
	public Vector3 LocalRotationAxe;
	public Sprite sprite_PickUp, sprite_Build, sprite_CutDown;
	public AudioSource _AudioSource;
	public AudioClip clipTimberBulid;
	private GameObject timb1, timb2;
	private AnimatorStateInfo ASI;
	private float tim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.R))
		{
			if(_Wood == 1)
			{
				TimberEmulation.SetActive(false);
				timb1.transform.position = TimberEmulation.transform.position;
				timb1.SetActive(true);
				timb1 = null;
				_Wood --;
				//timb1 = null;
			}
			if(_Wood == 2)
			{
				TimberEmulation.SetActive(false);
				timb1.transform.position = TimberEmulation.transform.position;
				timb1.SetActive(true);
				timb1 = null;
				TimberEmulation2.SetActive(false);
				timb2.transform.position = TimberEmulation2.transform.position;
				timb2.SetActive(true);
				timb2 = null;
				_Wood = 0;
			}
		}
		if(wood != null)
			if(hit.collider)
				if(hit.collider.gameObject.GetComponent<Wood>())
					if(wood.HP <= 0)
				{
					hit.collider.gameObject.GetComponent<Wood>()._treeUpParent.transform.rotation = Quaternion.Euler(0, Player.transform.eulerAngles.y, 0);
					hit.collider.gameObject.GetComponent<Wood>().DestroyWood();
					hack = 0;
					Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
					//ColliderAxe.enabled = false;
					wood = null;
				}
		if(hack == 1)
			if(Input.GetMouseButtonUp(0))
		{
			hack = 0;
			Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
			//ColliderAxe.enabled = false;
			wood = null;
		}
		if(Physics.Raycast(transform.position, transform.forward, out hit, DistanceRay))
		{
			if(hit.collider)
			{
				if(hit.collider.gameObject.tag == NameTagAxe)
				{
					
					Inform.sprite = sprite_PickUp;
					Inform.enabled = true;
					if(Input.GetKeyUp(KeyCode.E))
					{
						AXE = hit.collider.gameObject;
						_AnimatorAxe = AXE.GetComponent<GetAnimator>()._AnimatorAxe;
						_AnimatorAxe.speed = 1;
						//AXE.GetComponent<Collider>().enabled = false;
						Destroy(AXE.GetComponent<Rigidbody>());
						AXE.transform.parent = gameObject.transform;
						AXE.transform.localPosition = LocalPosAxe;
						AXE.transform.localRotation = Quaternion.Euler(LocalRotationAxe);
					}
				}
				else if(hit.collider.gameObject.tag == NameTagWood)
				{
					if(_AnimatorAxe != null)
					{
						ASI = _AnimatorAxe.GetCurrentAnimatorStateInfo(0);
						
						if(ASI.IsName(NameAnimationAxe))
						{
							ColliderAxe.enabled = true;
							tim = 0;
						}
						else
							if(!ASI.IsName(NameAnimationAxe))
						{
							print("1");
							ColliderAxe.enabled = false;
							
						}
					}
					if(AXE != null)
					{
						Inform.sprite = sprite_CutDown;
						Inform.enabled = true;
						if(hit.collider.gameObject.GetComponent<Wood>().HP > 0)
							if(Input.GetMouseButtonDown(0))
						{
							hack = 1;
							//Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
							ColliderAxe.enabled = true;
							//hit.collider.gameObject.GetComponent<Wood>().ForwardPlayer.transform.rotation = Quaternion.LookRotation(new Vector3(Player.transform.position.x, hit.collider.gameObject.GetComponent<Wood>().ForwardPlayer.transform.position.y, Player.transform.position.z) - 
							//   new Vector3(hit.collider.gameObject.GetComponent<Wood>().ForwardPlayer.transform.position.x, hit.collider.gameObject.GetComponent<Wood>().ForwardPlayer.transform.position.y, hit.collider.gameObject.GetComponent<Wood>().ForwardPlayer.transform.position.z));
							//Player.transform.position = new Vector3(hit.collider.gameObject.GetComponent<Wood>()._Position.transform.position.x, Player.transform.position.y, hit.collider.gameObject.GetComponent<Wood>()._Position.transform.position.z); 
							//Player.transform.rotation = Quaternion.Euler(0, hit.collider.gameObject.GetComponent<Wood>()._Position.transform.eulerAngles.y, 0);
							//transform.localRotation = Quaternion.Euler(0,0,0);
							wood = hit.collider.gameObject.GetComponent<Wood>();
						}
					}
				}
				else if(hit.collider.gameObject.tag == NameTagTimber)
				{
					Inform.sprite = sprite_PickUp;
					Inform.enabled = true;
					if(_Wood == 1)
					{
						if(Input.GetKeyUp(KeyCode.E))
						{
							hit.collider.gameObject.transform.parent = null;
							GameObject gm = Instantiate(hit.collider.gameObject, TimberEmulation2.transform.position, TimberEmulation2.transform.rotation) as GameObject;
							gm.SetActive(false);
							if(timb2 == null)
							{
								timb2 = gm;
							}
							Destroy(hit.collider.gameObject);
							_Wood ++;
							Inform.enabled = false;
							TimberEmulation2.SetActive(true);
						}
					}
					if(_Wood == 0)
					{
						
						Inform.enabled = true;
						if(Input.GetKeyUp(KeyCode.E))
						{
							hit.collider.gameObject.transform.parent = null;
							GameObject gm = Instantiate(hit.collider.gameObject, TimberEmulation.transform.position, TimberEmulation.transform.rotation) as GameObject;
							gm.SetActive(false);
							if(timb1 == null)
							{
								timb1 = gm;
							}
							Destroy(hit.collider.gameObject);
							_Wood ++;
							Inform.enabled = false;
							TimberEmulation.SetActive(true);
						}
					}
					
				}
				else if(hit.collider.gameObject.tag == NameTagHouse)
				{
					if(hit.collider.gameObject.GetComponent<House>().i < hit.collider.gameObject.GetComponent<House>().NumberWoodPart.Length - 1)
					{
						WoodNeeded.enabled = true;
						WoodInform.text = ""+(hit.collider.gameObject.GetComponent<House>().NumberWoodPart[hit.collider.gameObject.GetComponent<House>().i] - hit.collider.gameObject.GetComponent<House>().dpCount);
					}
					if(hit.collider.gameObject.GetComponent<House>().Builded == false)
						if(_Wood > 0)
					{
						Inform.sprite = sprite_Build;
						Inform.enabled = true;
						if(Input.GetMouseButtonDown(0))
						{
							
							if(_Wood >= hit.collider.gameObject.GetComponent<House>().NumberWoodPart[hit.collider.gameObject.GetComponent<House>().i])
							{
								if(hit.collider.gameObject.GetComponent<House>().dpCount == 0)
								{
									if(_Wood == hit.collider.gameObject.GetComponent<House>().NumberWoodPart[hit.collider.gameObject.GetComponent<House>().i])
									{
										timb1 = null;
										timb2 = null;
										TimberEmulation.SetActive(false);
										TimberEmulation2.SetActive(false);
									}
									if(_Wood > hit.collider.gameObject.GetComponent<House>().NumberWoodPart[hit.collider.gameObject.GetComponent<House>().i])
									{
										timb1 = null;
										TimberEmulation.SetActive(false);
									}
									int vr =  hit.collider.gameObject.GetComponent<House>().NumberWoodPart[hit.collider.gameObject.GetComponent<House>().i];
									hit.collider.gameObject.GetComponent<House>().BuildH(_Wood);
									_AudioSource.PlayOneShot(clipTimberBulid);
									_Wood -= vr;
									
								}
								if(hit.collider.gameObject.GetComponent<House>().dpCount != 0)
								{
									int b = hit.collider.gameObject.GetComponent<House>().NumberWoodPart[hit.collider.gameObject.GetComponent<House>().i] - hit.collider.gameObject.GetComponent<House>().dpCount;
									_Wood -= b;
									_AudioSource.PlayOneShot(clipTimberBulid);
									hit.collider.gameObject.GetComponent<House>().DPcoun(b);
									if(TimberEmulation.activeSelf == true)
									{
										timb1 = null;
										TimberEmulation.SetActive(false);
									}
									else
									{
										timb2 = null;
										TimberEmulation2.SetActive(false);
									}
								}
							}
							else if(_Wood > 0)
							{
								hit.collider.gameObject.GetComponent<House>().DPcoun(_Wood);
								_Wood = 0;
								_AudioSource.PlayOneShot(clipTimberBulid);
								if(TimberEmulation.activeSelf == true)
								{
									timb1 = null;
									TimberEmulation.SetActive(false);
								}
								else
								{
									timb2 = null;
									TimberEmulation2.SetActive(false);
								}
							}
						}
					}
				}
				else
				{
					WoodNeeded.enabled = false;
					WoodInform.text = "";
					Inform.enabled = false;
				}
				
				
			}
			else
			{
				WoodNeeded.enabled = false;
				WoodInform.text = "";
				Inform.enabled = false;
			}
		}
		else
		{
			WoodNeeded.enabled = false;
			WoodInform.text = "";
			Inform.enabled = false;
		}
	}
	
	void FixedUpdate () {
		if(_AnimatorAxe != null)
		{
			if(hack == 1)
			{
				if(hit.collider)
				{
					if(hit.collider.gameObject.tag == NameTagWood)
					{
						_AnimatorAxe.SetInteger(NameVarAxeAnimator, 1);
					}
					else
					{
						hack = 0;
						_AnimatorAxe.SetInteger(NameVarAxeAnimator, 0);
					}
				}
				else
				{
					hack = 0;
					ColliderAxe.enabled = false;
					_AnimatorAxe.SetInteger(NameVarAxeAnimator, 0);
				}
			}
			else
			{
				_AnimatorAxe.SetInteger(NameVarAxeAnimator, 0);
			}
			
			if(_Wood != 0)
				_AnimatorAxe.SetInteger(NameVarAxeUpDownAnimator, 0);
			else
				_AnimatorAxe.SetInteger(NameVarAxeUpDownAnimator, 1);
		}
	}
}
