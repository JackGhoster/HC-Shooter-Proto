using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IKillable
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Rigidbody[] _allRB;
    [SerializeField]
    private Collider _boxCol;

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
            //this.transform.gameObject.GetComponentInParent<EnemyCluster>().enemies.Remove(this.gameObject);
            //this.transform.gameObject.GetComponentInParent<EnemyCluster>().enemiesKilled++;
            //Died();
            LoseHealthPoints();
            CheckHealthPoints();
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
