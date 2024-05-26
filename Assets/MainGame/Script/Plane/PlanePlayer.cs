/*	  - Codeby Bui Thanh Loc -
	contact : builoc08042004@gmail.com
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePlayer : PlaneAbstract
{
    private void Start()
    {
        InvokeRepeating(nameof(FireBullet), 20f, FireSpeed);
    }
    private void Update()
    {
        if (this.gameObject != null)
        {
            Move();
        }
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        {
           transform.Translate(Vector2.up * MainSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * MainSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * MainSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { 
            transform.Translate(Vector2.right * MainSpeed * Time.deltaTime);
        }
    }

    private void FireBullet()
    {
        BulletPlayer bullet = GameManager.Instance.bulletPlayerPool.GetObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.gameObject.SetActive(true);
        }
    }
}
