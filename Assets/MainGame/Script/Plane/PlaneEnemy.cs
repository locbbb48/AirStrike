/*	  - Codeby Bui Thanh Loc -
	contact : builoc08042004@gmail.com
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaneEnemy : PlaneAbstract
{
    [SerializeField] private GameObject _Explore;

    [SerializeField] private float _radiusMove;

    [SerializeField] private Vector3 _randomPos;

    private void Start()
    {
        gameObject.GetComponent<PlaneEnemy>();
    }
    private void OnEnable()
    {
        _Explore.SetActive(false);
        _radiusMove = Random.Range(1f, 4f);
        currentHP = maxHP;
    }
    private void Update()
    {
        if (GameManager.Instance.isStartGamePlay)
        {
            if (currentHP <= 0)
            {
                _Explore.SetActive(true);
                GameManager.Instance.enemyPool.ReturnObject(this);
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isStartGamePlay)
        {
            RandomMove();
        }
    }

    private void RandomMove()
    {
        float angle = Random.Range(0, 360);
        _randomPos = transform.position + new Vector3(_radiusMove * Mathf.Cos(angle), _radiusMove * Mathf.Sin(angle), 0);
        transform.position = Vector3.MoveTowards(transform.position, _randomPos, MainSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            currentHP -= 1;
        }
    }
}
