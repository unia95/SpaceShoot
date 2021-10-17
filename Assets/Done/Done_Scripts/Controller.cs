using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary<T>
{
    public T xMin, xMax, zMin, zMax;
}

public class Controller : MonoBehaviour
{



    public float speed;
    public float tilt;
    public Done_Boundary<float> boundary;

    public GameObject shot;
    public Transform shotSpawn;
    //public float fireRate;
    
  

    public static float fire = (float)0.25;


    private float nextFire;
    void Start()
    {


    }

    void Update()
    {
        // PlayerPrefs.SetFloat("fireRate", 1 / 4);

        if (Input.GetKey(GameManager.GM.forward))
            transform.position += Vector3.forward / 5;
        if (Input.GetKey(GameManager.GM.backward))
            transform.position += -Vector3.forward / 5;
        if (Input.GetKey(GameManager.GM.left))
            transform.position += Vector3.left / 5;
        if (Input.GetKey(GameManager.GM.right))
            transform.position += Vector3.right / 5;
        if (Input.GetKey(GameManager.GM.attack) && Time.time > nextFire)
        {
            nextFire = Time.time + fire;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

        
    }
    
}
