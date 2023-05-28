using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Controls the movement aspect of a player
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private FixedJoystick _joystick;
    [SerializeField]
    private Button _shootingButton;

    [SerializeField]
    private InventoryObject _inventory;

    [SerializeField]
    private ItemObject _bullet;

    [SerializeField, Range(1f, 5f)]
    private float _moveSpeed = 2f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        _shootingButton.onClick.AddListener(Shoot);
    }

    private void FixedUpdate()
    {
        var moveVector = new Vector3(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed);
        _rigidbody.velocity = moveVector;
    }

    private void Shoot()
    {
        if (_inventory.CheckForItem(_bullet)){
            EventManager.Instance.Shooting();
            _inventory.RemoveItem(_bullet);
            _inventory.Save();        
        }
    }
}
