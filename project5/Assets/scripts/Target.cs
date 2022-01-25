using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //creates rigibody for throwing and rotating items
        Rigidbody targetRB;

        //gets rigibody
        targetRB = GetComponent<Rigidbody>();

        //adds force to throw and ands torque to rotate
        targetRB.AddForce(Vector3.up * RandomGen(10,20), ForceMode.Impulse);
        targetRB.AddTorque(RandomGen(0,20), RandomGen(0,20), RandomGen(0,20), ForceMode.Impulse);
        
        //randomized starting position
        this.transform.position = new Vector3(RandomGen(-5,5), -6);

    }

    int RandomGen(int point1, int point2)
	{
        return Random.Range(point1, point2);
	}

    // Update is called once per frame
    void Update()
    {
        
    }


}
