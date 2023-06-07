using UnityEngine;

public class EnemyCarMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        transform.Translate(Vector3.up * (speed * Time.deltaTime));
    }
}
