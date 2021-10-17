using UnityEngine;
using System.Collections;

/*[System.Serializable]
public class Done_Boundary<T>
{
	public T xMin, xMax, zMin, zMax;
}*/

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary<float> boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	
	void Update ()
	{
		if (Input.GetKey(GameManager.GM.attack) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
		if(Input.GetKey(GameManager.GM.forward));
			transform.position+=Vector3.forward/2;
		if(Input.GetKey(GameManager.GM.backward));
			transform.position+= -Vector3.forward/2;
		if(Input.GetKey(GameManager.GM.left));
			transform.position+=Vector3.left/2;
		if(Input.GetKey(GameManager.GM.right));
			transform.position+=Vector3.right/2;
		
			
			
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
