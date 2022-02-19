using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private readonly int torque = 10;
    private readonly int minPush = 10;
    private readonly int maxPush = 16;
    private readonly int xPos = 5;
    private readonly int yPos = -2;
    public int pointWorth;
    public GameManager GameManagerScript;


    // Start is called before the first frame update
    void Start()
    {
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

	}

	private void OnCollisionEnter(Collision collision)
	{
        Destroy(gameObject);
	}

}
