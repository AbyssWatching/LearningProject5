using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> target;
    public TextMeshProUGUI scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartCoroutine(SpawnTarget());
        ScoreToAdd(0);

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

    public void ScoreToAdd(int add)
	{
        score += add;
        scoreText.text = "Score: " + score;
	}
}
