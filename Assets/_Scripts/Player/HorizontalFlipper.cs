using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class HorizontalFlipper : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector3 _lookDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _lookDirection = transform.localScale;
    }
    private void Update()
    {
        if (_rigidbody.velocity.x > 0.5f) transform.localScale = _lookDirection;
        else if (_rigidbody.velocity.x < -0.5f)
        {
            transform.localScale = new Vector3(-_lookDirection.x, _lookDirection.y, _lookDirection.z);
        }

    }
}
