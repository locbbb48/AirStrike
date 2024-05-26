/*	  - Codeby Bui Thanh Loc -
	contact : builoc08042004@gmail.com
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAbstract : MonoBehaviour
{
    public float Speed;
    public bool isColl = false;
    public bool isSetActive = false;

    public float maxDistance = 10f;

    public Vector3 startPosition;

    public void OnEnable()
    {
        isSetActive = true;
    }

    public virtual void Update()
    {
        DeActivebyDistance();
    }

    public void DeActivebyDistance()
    {
        if (this.transform.position.y >= maxDistance)
        {
            isSetActive = false;
            BulletPlayer bullet = this.gameObject.GetComponent<BulletPlayer>();
            GameManager.Instance.bulletPlayerPool.ReturnObject(bullet) ;
        }
    }
}
