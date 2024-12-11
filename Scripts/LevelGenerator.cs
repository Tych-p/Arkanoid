
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] brickPrefabs;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private Vector2 startPosition;

    [SerializeField] private List<List<int>> levelData = new List<List<int>>();
    
    void Start()
    {
        levelData.Add(new List<int>{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0});
        levelData.Add(new List<int>{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0});
        levelData.Add(new List<int>{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0});
        levelData.Add(new List<int>{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0});
        levelData.Add(new List<int>{0,9,0,0,9,0,0,9,0,9,0,0,9,0,0,9,0,9,0,0,9,0,0,9,0,9,0,0,9,0});
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int row = 0; row < levelData.Count; row++)
        {
            for (int col = 0; col < levelData[row].Count; col++)
            {
                int brickType = levelData[row][col];
                if (brickType >= 0 && brickType < brickPrefabs.Length)
                {
                    Vector2 position = new Vector2(startPosition.x + col * (brickPrefabs[brickType].transform.localScale.x + offsetX),
                        startPosition.y - row * (brickPrefabs[brickType].transform.localScale.y + offsetY));
                    Instantiate(brickPrefabs[brickType], position, Quaternion.identity);
                }
            }
        }
    }
}
