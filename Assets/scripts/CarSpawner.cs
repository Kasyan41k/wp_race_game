using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] cars;
    public float maxPos = 2.39f;
    public float delayTimer = 0.9f;
    float timer;
    int carNumber;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", 0.7f, delayTimer);
    }

    // Update is called once per frame
    void Spawner()
    {
        Vector3 carPos = new Vector3(Random.Range(-2.39f, 2.39f), transform.position.y, transform.position.z);
        carNumber = Random.Range(0, cars.Length);
        Instantiate(cars[carNumber], carPos, transform.rotation);
        timer = delayTimer;
    }
}
