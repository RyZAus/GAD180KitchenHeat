using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPot : MonoBehaviour
{
    public GameObject smokeCloud;
    public float respawnTime = 1;
    public float killTime = 4;

	private void Start()
	{
        StartCoroutine(smokeWave());
	}
	void spawnSmoke()
    {
        GameObject a = Instantiate(smokeCloud) as GameObject;
        a.transform.position = new Vector3(Random.Range(6,9), -1, 0);
        a.transform.eulerAngles = new Vector3(0, 0, Random.Range(-30, 30));
    }
    IEnumerator smokeWave()
	{
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnSmoke();
        }
	}

    IEnumerator SmokeGo()
    {
        while (true)
        {
            yield return new WaitForSeconds(killTime);
            Destroy(smokeCloud);
        }
    }
}
