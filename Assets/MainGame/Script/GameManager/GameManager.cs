/*	  - Codeby Bui Thanh Loc -
	contact : builoc08042004@gmail.com
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isStartGamePlay = false;

    public ObjectPool<BulletPlayer> bulletPlayerPool;
    public ObjectPool<PlaneEnemy> enemyPool;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnerEnemy), 20f, 5f);
    }

    private void Update()
    {
        if(isStartGamePlay)
        {
            if(enemyPool.ActiveParent.childCount == 0)
            {
                CancelInvoke(nameof(SpawnerEnemy));
            }
        }
    }

    private void SpawnerEnemy()
    {
        PlaneEnemy enemy = enemyPool.GetObject();
        Vector3 newPosition = new Vector3(Random.Range(-8, 8), Random.Range(0, 4), enemy.transform.position.z);
        enemy.transform.position = newPosition;
        enemy.gameObject.SetActive(true);
    }
}
