using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		if(!other.CompareTag("Player"))
			Destroy(other.gameObject);
		
	}
	
}