using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    [SerializeField] Transform follow;
    GridLayout gridLayout;
    Grid grid;

    private void Start()
    {
        gridLayout = EnemySpawner.current.gridLayout;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        snapToGrid(follow.position);
    }

    private void snapToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position); 
        transform.position = grid.GetCellCenterWorld(cellPos); 
    }
}
