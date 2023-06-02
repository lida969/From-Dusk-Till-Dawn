using System.Threading;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float _shotRange;
    private Player _player;
    [SerializeField] private int _damage;
    [SerializeField] private float _coolDown;
    public Transform enemyGunPoint;
    public GameObject bullet;
    public EnemyHealth dead;

    private float _timer;
    public float timeBetweenShooting = 1f;
    public float breakTime = 3f;

    private bool _readyToShoot;
    private float _timerCountdown;
    public float AttackRange => _shotRange;

    private void Awake()
    {
        _readyToShoot = true;
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public void TryShootPlayer()
    {

        if (_readyToShoot)
        {
            if (_timerCountdown <= 0)
            {
                ShootPlayer();
                _timerCountdown = timeBetweenShooting;
                _readyToShoot = false;
            }
            else
            {
                _timerCountdown -= Time.deltaTime;
            }
        }
        else
        {
            if (breakTime <= 0)
            {
                _readyToShoot = true;
                breakTime = 1f;
            }
            else
            {
                breakTime -= Time.deltaTime;
            }
        }
    }

    

    private void ShootPlayer()
    {
        Ray ray = new Ray(enemyGunPoint.position, enemyGunPoint.forward);
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);
        Vector3 direction = targetPoint - enemyGunPoint.position;
        GameObject currentBullet = Instantiate(bullet, enemyGunPoint);

        // Reset the shooting readiness after shooting
        _readyToShoot = false;
        _timerCountdown = timeBetweenShooting;
    }
}