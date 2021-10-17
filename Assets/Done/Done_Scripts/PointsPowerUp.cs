using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsPowerUp : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Done_GameController.scorePowerUp = true;
            Done_GameController.powerupactive = true;


        }
    }
}
