/*	  - Codeby Bui Thanh Loc -
	contact : builoc08042004@gmail.com
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : BulletAbstract
{
    private new void Update()
    {
        base.Update();
        transform.Translate(Vector2.up * Speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //BulletPlayer bullet = this.gameObject.GetComponent<BulletPlayer>();
            GameManager.Instance.bulletPlayerPool.ReturnObject(this);
        }
    }
}
