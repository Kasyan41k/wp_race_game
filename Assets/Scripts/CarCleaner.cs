using UnityEngine;

public class CarCleaner : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy Car")) 
        {
            Destroy(collision.gameObject);
        }
    }
}
