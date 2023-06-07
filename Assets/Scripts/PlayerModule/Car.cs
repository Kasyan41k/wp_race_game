using System;
using UnityEngine;

namespace PlayerModule
{
    public class Car : MonoBehaviour
    {
        [SerializeField] public float carSpeed;
        private  Vector2 _carPosition;

        public event Action Died;
        
        private void Start()
        {
            _carPosition = transform.position;
        }
        
        private void Update()
        {
            _carPosition.x += Input.GetAxis("Horizontal") * carSpeed * Time.deltaTime;

            _carPosition.x = Mathf.Clamp(_carPosition.x, -2.39f, 2.39f);

            transform.position = _carPosition;
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Enemy Car"))
            {
                Destroy(col.gameObject);
                Died?.Invoke();
            }
        }
    }
}