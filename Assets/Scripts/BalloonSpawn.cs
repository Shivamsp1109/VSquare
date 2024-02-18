using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawn : MonoBehaviour
{
    public float MinX, MaxX;
    public GameObject[] Balloons;
    public float MaxTime;
    float currentTime = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= MaxTime)
        {
            // float yPos = 45;
            GameObject temp = Instantiate(Balloons[Random.Range(0, Balloons.Length)], new Vector3(Random.Range(MinX, MaxX), this.transform.position.y, 0), Quaternion.identity);
            currentTime = 0;
        }
    }
}
