using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public GameObject grass;
    public GameObject water;

    int[][] map;
    GameObject[] GOs;

    private struct Player
    {
        private int x;
        private int y;
        private string login;
        private string nick;
    };

    int my_x = 5;
    int my_y = 5;

    int wind_x = 2;
    int wind_y = 2;

    Player[] players = new Player[1];

    private void initPlayers()
    {
        
    }


    bool spriteInWind(int y, int x)
    {
        return true;
        if(Mathf.Abs(my_y - y) < wind_y && Mathf.Abs(my_x - x) < wind_x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void initMap()
    {
        GOs = new GameObject[3];
        GOs[1] = water;
        GOs[2] = grass;
        map = new int[][]
        {
            new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 2, 2, 2, 2, 2, 2, 2, 2, 1},
            new int[] {1, 2, 2, 2, 2, 2, 2, 2, 2, 1},
            new int[] {1, 2, 2, 2, 2, 2, 2, 2, 2, 1},
            new int[] {1, 2, 2, 2, 2, 2, 2, 1, 1, 1},
            new int[] {1, 2, 2, 2, 2, 2, 2, 1, 1, 1},
            new int[] {1, 2, 2, 2, 2, 2, 2, 2, 2, 1},
            new int[] {1, 2, 2, 2, 2, 2, 2, 2, 2, 1},
            new int[] {1, 2, 2, 2, 2, 2, 2, 2, 2, 1},
            new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},

        };
    }

    void updateMap()
    {
  
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                if (spriteInWind(y, x))
                {
                    GameObject prefab = GOs[map[y][x]];
                    //cube.AddComponent<Rigidbody>();
                    //cube.transform.position = new Vector3(x, y, 0);
                    GameObject block = (GameObject)Instantiate(prefab, new Vector3(x, 0, y), Quaternion.identity);
                    block.name = y.ToString() + " " + x.ToString();
                    Debug.Log(y.ToString() + " " + x.ToString());
                }
                else
                {
                    GameObject block = GameObject.Find(y.ToString() + " " + x.ToString());
                    if(block != null)
                    {
                        
                        Destroy(GameObject.Find(y.ToString() + " " + x.ToString()));
                    }
                }
            }
        }
    }

   
    void Start()
    {
        initPlayers();

        initMap();

        updateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
