using UnityEngine;

public class TrackMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Renderer renderer;
    private Vector2 _offset;
    
    private void Update()
    {
        _offset = new Vector2(0, Time.time * speed);
        renderer.material.mainTextureOffset = _offset;
    }
}
