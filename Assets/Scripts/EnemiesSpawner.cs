using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;
    [SerializeField] private float maxPos = 2.39f;
    [SerializeField] private float delayTimer = 0.9f;
    private float _timer;
    private int _carNumber;

    public void StartSpawn()
    {
        if(!IsInvoking(nameof(SpawnEnemy))) InvokeRepeating(nameof(SpawnEnemy), 0.7f, delayTimer);
    }

    public void StopSpawn()
    {
        if(IsInvoking(nameof(SpawnEnemy))) CancelInvoke(nameof(SpawnEnemy));
    }

    private void SpawnEnemy()
    {
        Vector3 carPos = new Vector3(Random.Range(-2.39f, 2.39f), transform.position.y, transform.position.z);
        _carNumber = Random.Range(0, cars.Length);
        Instantiate(cars[_carNumber], carPos, transform.rotation);
        _timer = delayTimer;
    }
}
