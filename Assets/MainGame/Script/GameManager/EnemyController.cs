/*	  - Codeby Bui Thanh Loc -
	contact : builoc08042004@gmail.com
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _enemyCount = 16;

    [SerializeField] private float _moveSpeed = 2f;

    [SerializeField] private Vector2 _offScreenPoint;
    [SerializeField] private Vector2 _startPoint;

    [SerializeField] private float _distanceEachEnemy = 1f;

    [SerializeField] private List<PlaneEnemy> Enemies = new List<PlaneEnemy>();

    private Vector2[] squareFormationPositions = new Vector2[16];
    private Vector2[] diamondFormationPositions = new Vector2[16];
    private Vector2[] triangleFormationPositions = new Vector2[16];
    private Vector2[] rectangleFormationPositions = new Vector2[16];

    private void Start()
    {

        for(int i = 0; i < _enemyCount; i++)
        {
            PlaneEnemy enemy = GameManager.Instance.enemyPool.GetObject();
            enemy.transform.position = _offScreenPoint;
            enemy.gameObject.SetActive(true);
            Enemies.Add(enemy);
        }
        StartCoroutine(MoveEnemiesToSquareFormation());
        StartCoroutine(MoveEnemiesToDiamondFormation());
        StartCoroutine(MoveEnemiesToTriangleFormation());
        StartCoroutine(MoveEnemiesToRectangleFormation());
    }

    private void MakeSquare()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                squareFormationPositions[i * 4 + j] = _startPoint
                    + new Vector2(i * _distanceEachEnemy, j * _distanceEachEnemy);
            }
        }
    }
    private void MakeDiamond()
    {
        _startPoint = new Vector2(0, 2);
        int index = 0;
        
        int[] rows = { 1, 4, 6, 4, 1 };
        for (int i = 0; i < 5; i++)
        {
            _startPoint = new Vector2(0, 2);
            float y = (2 - i) * _distanceEachEnemy;
            for (int j = 0; j < rows[i]; j++)
            {
                float x = (j - rows[i] / 2) * _distanceEachEnemy;
                if ((index + 2) % 5 == 0)
                {
                    x += _distanceEachEnemy;
                    diamondFormationPositions[index++] = _startPoint + new Vector2(x, y);
                    _startPoint.x += _distanceEachEnemy;
                }
                else
                {
                    diamondFormationPositions[index++] = _startPoint + new Vector2(x, y);
                }
            }
        }
    }
    private void MakeTriangle()
    {
        _startPoint = new Vector2(0, 2);

        int index = 0;
        int[] rows = { 1, 2, 2, 2, 9 };
        for (int i = 0; i < 4; i++)
        {
            float y = (2 - i) * _distanceEachEnemy;
            for (int j = 0; j < rows[i]; j++)
            {
                float x = _distanceEachEnemy * (-i) + (i * 2) * j;
                triangleFormationPositions[index++] = _startPoint + new Vector2(x, y);
            }
        }
        _startPoint += new Vector2(-4, -2);

        for (int i=0; i<9; i++)
        {
            triangleFormationPositions[index++] = _startPoint;
            _startPoint.x += 1;
        }

    }
    private void MakeRectangle()
    {
        _startPoint = new Vector2(0, 2);

        int index = 0;
        int[] rows = { 7, 2, 7};
        for(int i = 0; i < 3; i++)
        {
            float y = (2 - i) * _distanceEachEnemy;
            for (int j = -3; j < rows[i]-3; j++)
            {
                float x = _distanceEachEnemy * j + 6 * (j+3) / (rows[i] - 1);
                rectangleFormationPositions[index++] = _startPoint + new Vector2(x, y);
            }
        }

    }


    private IEnumerator MoveEnemiesToSquareFormation()
    {
        MakeSquare();
        for (int i = 0; i < Enemies.Count; i++)
        {
            while ((Vector2)Enemies[i].transform.position != squareFormationPositions[i])
            {
                Enemies[i].transform.position = Vector2.MoveTowards(Enemies[i].transform.position, 
                    squareFormationPositions[i], _moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
    private IEnumerator MoveEnemiesToDiamondFormation()
    {
        MakeDiamond();
        yield return new WaitForSeconds(5);

        for (int i = 0; i < Enemies.Count; i++)
        {
            while ((Vector2)Enemies[i].transform.position != diamondFormationPositions[i])
            {
                Enemies[i].transform.position = Vector2.MoveTowards(Enemies[i].transform.position,
                    diamondFormationPositions[i], _moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
    private IEnumerator MoveEnemiesToTriangleFormation()
    {
        MakeTriangle();
        yield return new WaitForSeconds(10);

        for (int i = 0; i < Enemies.Count; i++)
        {
            while ((Vector2)Enemies[i].transform.position != triangleFormationPositions[i])
            {
                Enemies[i].transform.position = Vector2.MoveTowards(Enemies[i].transform.position,
                    triangleFormationPositions[i], _moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
    private IEnumerator MoveEnemiesToRectangleFormation()
    {
        MakeRectangle();
        yield return new WaitForSeconds(15);

        for (int i = 0; i < Enemies.Count; i++)
        {
            while ((Vector2)Enemies[i].transform.position != rectangleFormationPositions[i])
            {
                Enemies[i].transform.position = Vector2.MoveTowards(Enemies[i].transform.position,
                    rectangleFormationPositions[i], _moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        GameManager.Instance.isStartGamePlay = true;
    }

}
