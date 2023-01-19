using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
        
    private GameManager _gameManager;
    private EventManager _eventManager;



    private void Awake()
    {
        _animator = GetComponent<Animator>();   
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.current.ShootingEnded();
        }
    }


    private void OnEnable()
    {
        _animator.SetBool("Shooting", true);
    }

    private void OnDisable()
    {
        _animator.SetBool("Shooting", false);
    }  
}
