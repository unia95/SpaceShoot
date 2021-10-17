using UnityEngine;
using System.Collections;

public class Done_Mover1 : accelerations
{	

	void Start ()
	{
		
		GetComponent<Rigidbody>().velocity = transform.forward * speed;

	}


	void Update(){
		
	}
	public override void need_acceleration ()
	{

		float distanza = Vector3.Distance (transform.position, player.transform.position);
		if (distanza <= D  ) {
			

						GetComponent<Rigidbody> ().velocity = transform.forward * speed*20 ;}
		}
	}

