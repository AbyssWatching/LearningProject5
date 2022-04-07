using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //where and how to throw presets
    private readonly int torque = 10;
    private readonly int minPush = 10;
    private readonly int maxPush = 16;
    private readonly int xPos = 5;
    private readonly int yPos = -2;

    //how many points each item is worth
    public int pointWorth;

    //grabing GM script to converse with it
    public GameManager GameManagerScript;

    //explosion
    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
        //grabbing that script
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        //creates rigibody for throwing and rotating items
        Rigidbody targetRB;

        //gets rigibody
        targetRB = GetComponent<Rigidbody>();

        //adds force to throw and ands torque to rotate
        targetRB.AddForce(ForcePush(), ForceMode.Impulse);
        targetRB.AddTorque(TorqueRan(),TorqueRan(),TorqueRan(), ForceMode.Impulse);
        
        //randomized starting position
        this.transform.position = StartingPos();

    }

    //throws target up
    Vector3 ForcePush()
	{

        return Vector3.up * Random.Range(minPush,maxPush);

    }

    //start position of target
    Vector3 StartingPos()
	{
        return new Vector3(Random.Range(-xPos,xPos),yPos);
	}

    //torques targert
    int TorqueRan()
    {
        return Random.Range(-torque, torque);
    }

    

    // Update is called once per frame
    void Update()
    {
        

    }

	private void OnMouseDown()
	{
        Destroy(gameObject);
        GameManagerScript.ScoreToAdd(pointWorth);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

	}

	//private void OnCollisionEnter(Collision other)
	//{
	//	if (other.gameObject.tag == "sensor")
	//	{
 //           Destroy(gameObject);
 //       }
 //   }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("sensor"))
		{
            Destroy(gameObject);
		}
	}

}
