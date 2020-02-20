using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerate : MonoBehaviour
{
    public NavMeshSurface surface;
    public GameObject wall;
    public GameObject player;
    public float width = 9f;
    public float height = 9f;

    private bool spawned = false;

    void Start()
    {
        GenerateLevel();
        surface.BuildNavMesh();
    }
    void GenerateLevel()
    {
        for (int x = 0; x <= width; x += 2)
        {
            for (int y = 0; y <= height; y += 2)
            {
                if (Random.value > 0.7f)
                {
                    Vector3 wallPos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
                    Instantiate(wall, wallPos, Quaternion.identity, transform);
                }
                else if (!spawned) //if not spawned player
                {
                    Vector3 playerPos = new Vector3(x - width / 2f, 1.5f, y - height / 2f);
                    Instantiate(player, playerPos, Quaternion.identity);
                    spawned = true;
                };
            }
        }
    }
}
