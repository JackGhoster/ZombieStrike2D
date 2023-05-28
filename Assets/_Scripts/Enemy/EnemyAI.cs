using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    private float _triggerDistance = 5f;
    private float _speed = 1f;

    private void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").gameObject.transform;   
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamageOverTime(recipient: collision, tag: collision.tag);
    }

    /// <summary>
    /// Deals damage to the HealthSystem of an object!
    /// </summary>
    /// <param name="recipient">Recipient of a damage</param>
    /// <param name="tag">Tag of the recipient</param>
    private void DealDamageOverTime(Collider2D recipient, string tag)
    {
        if (recipient.CompareTag(tag))
        {
            HealthManager healthManager = recipient.GetComponent<HealthManager>();
            healthManager.UpdateHealth(value: Random.Range(1f, 10f), substractFromHealth: true);
        }
        this.gameObject.GetComponent<Collider2D>().enabled = false;//turning off so it will retrigger this Func
        Invoke(nameof(EnableCollider), 1f);
    }

    private void EnableCollider()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }

    private void FollowPlayer()
    {
        if (_playerTransform != null)
        {
            if (Vector2.Distance(transform.position, _playerTransform.position) < _triggerDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
            }
        }
    }

  
}
