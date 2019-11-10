using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    public GameObject diamonds;
    public static int numOfPlatforms = 0;

    Vector3 lastPos;
    float size;

	
	void Start () {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
        SpawnZ();
        
       
    }
	public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.1f);
    }
	
	void Update () {
        if(GameManager.GMInstance.gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
        
	}

    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if (rand < 3)
        {
           
                SpawnX();
            
        }
        else if (rand >= 3)
        {
                SpawnZ();
           
        }
        
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        numOfPlatforms++;
        Vector3 diamondPos = new Vector3(pos.x, 1f, pos.z);
        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamonds, diamondPos, diamonds.transform.rotation);
        }
        

    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        numOfPlatforms++;
        Vector3 diamondPos = new Vector3(pos.x, 1f, pos.z);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamonds, diamondPos, diamonds.transform.rotation);
        }
    }
}
