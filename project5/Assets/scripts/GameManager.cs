using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> target;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnTarget()
	{
        while (true)
        {
            yield return new WaitForSeconds(1);
            int index = Random.Range(0, target.Count);
            Instantiate(target[index]);
        }

	}
}
