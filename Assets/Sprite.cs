using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    [SerializeField] Transform follow;
    [SerializeField] GridLayout gridLayout;
    Grid grid;

    private void Start()
    {
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
