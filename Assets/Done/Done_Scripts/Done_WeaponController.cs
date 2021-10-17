using UnityEngine;
using System.Collections;

public class Done_WeaponController : MonoBehaviour
{
	public float Distanza;
	public Transform player;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	public AudioSource clip;

	void Start ()
	{
		clip = GetComponent<AudioSource>();
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		//GetComponent<AudioSource>().Play();
		AudioHandler.Instance.PlayAudio(clip);
	}
}
