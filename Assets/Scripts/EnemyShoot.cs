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


    private float _timer;
    public float timeBetweenShooting = 1f; // <-- Added this line
    public float breakTime = 3f; // <-- Added this line
    /*public float timeBetweenShooting;*/
    public bool allowInvoke = true;

    private const float TIMER_MAX_TIME = 80000f;
    private float timerCurrentTime = TIMER_MAX_TIME;

    public Rigidbody playerRb;
    public float recoilForce;
    bool readyToShoot;
    public bool CanAttack { get; private set; }
    public float AttackRange => _shotRange;

    public bool _alive = true;

    private void Awake()
    {
        readyToShoot = true;
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        /*if (timerCurrentTime > 0)
        {
            timerCurrentTime -= Time.deltaTime;
        }
        else
        {
            TryShootPlayer();
            timerCurrentTime = TIMER_MAX_TIME;
        }*/

        if (_alive == false)
        {
            Destroy(gameObject);
        }

        if (breakTime <= 0)
        {
            TryShootPlayer();
            breakTime = 1f;
        }
        else
        {
            breakTime -= Time.deltaTime;
        }
    }
    public void TryShootPlayer()
    {
        readyToShoot = false;

        Ray ray = new Ray(enemyGunPoint.position, enemyGunPoint.forward);
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);
        Vector3 direction = targetPoint - enemyGunPoint.position;
        GameObject currentBullet = Instantiate(bullet, enemyGunPoint);

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
            playerRb.AddForce(-direction.normalized * recoilForce, ForceMode.Impulse);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
}