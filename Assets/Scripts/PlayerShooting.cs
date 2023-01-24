using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    /// <summary>
    /// Behavior of the player that defines Shooting logic of the player.
    /// Component should be disabled as default.
    /// Can be set enabled only upon entering Shooting State.
    /// </summary>
    public Vector3 BulletDirection { get; private set; }

    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private AudioSource _shotSFX;
    [SerializeField]
    private Transform _bulletSpawnPoint;
    

    private TouchManager _touchManager;
    private GameManager _gameManager;
    private EventManager _eventManager;

    private Vector3 _touchPos;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _touchManager = GameObject.FindGameObjectWithTag("TouchManager").GetComponent<TouchManager>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _eventManager = EventManager.current;
        _gameManager = GameManager.current;

        _animator.SetBool("Shooting", true);
        
    }

    private void Update()
    {             
    }

    /// <summary>
    /// Takes the position of the last touch and draws a ray from camera to this position.
    /// Next sets the ray as a direction of the bullet and invokes ShootBullet Method.
    /// </summary>
    private void AimLogic()
    {
        //Debug.Log($"Touch pos in Shooting: {_touchManager.TouchPosition}");
        _touchPos = _touchManager.TouchPosition;
        var ray = _camera.ScreenPointToRay(_touchPos);
        BulletDirection = ray.direction;
        ShootBullet();
    }
    /// <summary>
    /// Takes a bullet from the pooler if available.
    /// And plays a sound!
    /// </summary>
    private void ShootBullet()
    {
        GameObject bullet = ObjectPooler.current.GetPooledObject();
        if (bullet != null)
        {           
            _shotSFX.Play();
            bullet.transform.position = _bulletSpawnPoint.position;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().enabled = true;
        }
    }


    private void OnEnable()
    {
        _animator.SetBool("Shooting", true);
        EventManager.current.OnScreenPressed += AimLogic;
    }

    private void OnDisable()
    {
        _animator.SetBool("Shooting", false);
        EventManager.current.OnScreenPressed -= AimLogic;
    }  

}
