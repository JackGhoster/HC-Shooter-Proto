using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCluster : MonoBehaviour
{
    [SerializeField]
    private int _id;
    [SerializeField]
    private int _currentCluster;
    public List<GameObject> enemies = new List<GameObject>();
    public int enemiesKilled = 0;

    // Start is called before the first frame update
    void Start()
    {      
        EventManager.current.OnKill += EnemyGotKilled;
        _currentCluster = GameManager.current.currentEnemyCluster;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EnemyGotKilled()
    {
        _currentCluster = GameManager.current.currentEnemyCluster;
        if (_id != _currentCluster) return;
        enemiesKilled++;
        if (enemiesKilled == enemies.Count)
        {
            Debug.Log("Shooting Ended");
            EventManager.current.ShootingEnded();
        }
    }


}
