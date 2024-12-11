using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 10f;

    private Vector2 _direction;
    private Rigidbody2D _rb;
    private bool _isLaunched = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (!_isLaunched && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            LaunchBall();
        }
    }

    private void FixedUpdate()
    {
        if (!_isLaunched)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                transform.position.y,
                transform.position.z);
        }
        if (_rb.velocity.magnitude < initialSpeed * 0.9f)
        {
            _rb.velocity = _rb.velocity.normalized * initialSpeed;
        }
    }

    private void LaunchBall()
    {
        _isLaunched = true;
        Vector2 launchDirection = new Vector2(Random.Range(-0.3f, 0.3f), 1f).normalized;
        _direction = launchDirection;
        _rb.velocity = launchDirection * initialSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PuddleController>())
        {
            float hitPoint = collision.contacts[0].point.x - collision.transform.position.x;
            float paddleWidth = collision.collider.bounds.size.x;

            float bounceAngle = hitPoint / (paddleWidth / 2);
            
            _direction = new Vector2(bounceAngle, 1).normalized;
            _rb.velocity = _direction * initialSpeed;
        }
        else
        {
            Vector2 normal = collision.contacts[0].normal;
            _direction = Vector2.Reflect(_direction, normal).normalized;
            _rb.velocity = _direction * initialSpeed;
        }
    }
}
