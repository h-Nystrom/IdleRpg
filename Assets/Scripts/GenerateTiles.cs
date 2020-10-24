using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTiles : MonoBehaviour {
    public GameObject PlayerTilePrefab;
    public GameObject EnemyTilePrefab;
    public Transform[] rowParent;

    public List<Transform[]> gameGrid = new List<Transform[]> ();
    const int tilesAmount = 8;
    void Awake () {
        for (int i = 0; i < rowParent.Length; i++) {
            Transform[] rowTiles = new Transform[8];
            for (int tile = 0; tile < 8; tile++) {
                if (tile < 4) {
                    GameObject playerTile = Instantiate (PlayerTilePrefab, rowParent[i]) as GameObject;
                    playerTile.name = $"C:{i}R{tile}";
                    rowTiles[tile] = playerTile.transform;
                } else {
                    GameObject enemyTile = Instantiate (EnemyTilePrefab, rowParent[i]) as GameObject;
                    enemyTile.name = $"C:{i}R{tile}";
                    rowTiles[tile] = enemyTile.transform;
                }
                gameGrid.Add (rowTiles);
            }
        }
    }
}