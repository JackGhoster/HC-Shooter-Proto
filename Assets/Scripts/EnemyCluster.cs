using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCluster : MonoBehaviour
{
    /// <summary>
    /// Object with this component attached will act as a container with an ID where you can put enemies, and whenever
    /// an enemy dies it checks whether the enemy died in this container and if so then it increments the kill count
    /// until it's the same as the number of enemies in this container and if so then it increments
    /// the current container's ID
    /// </summary>

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
        EventManager.current.OnShootingEnded += ChangeCurrentCluster;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EnemyGotKilled()
    {        
        if (_id != _currentCluster) return;
        enemiesKilled++;

        if (enemiesKilled == enemies.Count)
        {
            Debug.Log("Shooting Ended");
            EventManager.current.ShootingEnded();
        }
    }

    private void ChangeCurrentCluster()
    {
        StartCoroutine(WaitForChangesBeforeIncrementing());
        
    }

    IEnumerator WaitForChangesBeforeIncrementing()
    {
        yield return new WaitForSeconds(0.5f);
        _currentCluster++;
    }
    
}
