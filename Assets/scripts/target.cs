using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class target : MonoBehaviour
{
    private Rigidbody targetrb;
    private float minspeed = 16;
    private float maxspeed = 20;
    private float maxtorque = 100;
    private float xRange = 10;
    private float xspawn = -8;
    private bool canBeDestroyed = true;
    private  GameManager gamemanager;
    public int pointvalue;
    public ParticleSystem explosionparticle;

    void Start()
    {
        
        gamemanager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetrb = GetComponent<Rigidbody>();
        targetrb.AddForce(RandomRange(), ForceMode.Impulse);
        targetrb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawn();
    }
    Vector3 RandomRange()
    {
        // Return the force as a Vector3
        return Vector3.up * Random.Range(minspeed, maxspeed);
    }
    private void OnMouseDown()
    {
        if (gamemanager.isgameactive)
        {
            Destroy(gameObject);
            Instantiate(explosionparticle,transform.position,explosionparticle.transform.rotation);
            gamemanager.UpdateScore(pointvalue);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("bad1"))
        {
            gamemanager.Gameover();
        }
    }
    float RandomTorque()
    {
        return Random.Range(-maxtorque, maxtorque);
    }
    Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-xRange, xRange), xspawn);
    }
}


