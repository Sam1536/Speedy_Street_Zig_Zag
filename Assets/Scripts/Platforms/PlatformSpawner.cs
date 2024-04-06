using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    private Vector3 lastPosition;
    private Vector3 newPos;
    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnerPlatforms());

        

        //if (Input.GetKeyDown(KeyCode.Space)) //test
        //{
        //    SpawnerPlatform();
        //}
    }


    IEnumerator SpawnerPlatforms()
    {

        while (!stop)
        {
            GeneratePosition();

            Instantiate(platform, newPos, Quaternion.identity);

            lastPosition = newPos;

            yield return new WaitForSeconds(500f);
        }

       
    }

    //void SpawnerPlatform() //spawner manual 
    //{
    //    GeneratePosition();

    //    Instantiate(platform, newPos,Quaternion.identity);

    //    lastPosition = newPos;
    //}

    void GeneratePosition()
    {
        newPos = lastPosition;

        int rand = Random.Range(0,2);

        if(rand > 0)
        {
            newPos.x += 2f;
        }
        else
        {
            newPos.z += 2f;
        }

      
        
      
    }
}
