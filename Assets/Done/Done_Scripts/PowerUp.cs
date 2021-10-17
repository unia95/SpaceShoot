using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour {


 

    //static float fire;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Controller.fire = (float)0.01;
            Destroy(this.gameObject);
            Done_GameController.Powerup2 = true;

           

        }
    }
       

    
}
