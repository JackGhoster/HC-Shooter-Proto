
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IKillable
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Rigidbody[] _allRB;
    [SerializeField]
    private Collider _boxCol;
    [SerializeField]
    private Slider _hpSlider;
    private int _hp;


    private void Awake()
    {

        _boxCol = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
        for (int i = 0; i < _allRB.Length; i++)
        {
            _allRB[i].isKinematic = true;
        }
    }

    private void Start()
    {
        _hp = MaxHealthPoints();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            LoseHealthPoints();
            CheckHealthPoints();
            float health = Mathf.LerpUnclamped(_hp, 0, 0.5f);
            _hpSlider.value = health;
        }
    }

    public void Died()
    {
        _boxCol.enabled = false;
        _animator.enabled = false;       
        EventManager.current.Killed();
        //turning the ragdoll on
        for (int i = 0; i < _allRB.Length; i++)
        {
            _allRB[i].isKinematic = false;
        }
    }

    public int MaxHealthPoints()
    {
        return Random.Range(1,3);
    }

    public int LoseHealthPoints()
    {
        return _hp--;
    }

    public void CheckHealthPoints()
    {
        if (_hp == 0)
        {
            Died();
        }
    }
}
