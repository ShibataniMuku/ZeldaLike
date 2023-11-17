using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class StageGenerater : MonoBehaviour
{

    [SerializeField] private GameObject player = null;
    [SerializeField] private GameObject goal = null;

    const int fieldSize = 21;

    // 0 => •Ç
    // 1 => ’Ê˜H
    // 
    [SerializeField] private int[,] field = new int[fieldSize, fieldSize];


    [SerializeField] private GameObject wall = null;
    [SerializeField] private GameObject path = null;

    [SerializeField] private GameObject[] enemies = null;

    // Start is called before the first frame update
    void Start()
    {

        Dig(1, 1);

        for (int x = 0; x < this.field.GetLength(0); x++)
        {
            for (int y = 0; y < this.field.GetLength(1); y++)
            {
                Vector3 pos = new Vector3(x * 3, y * 3, 0);

                if (this.field[x,y] == 0)
                {
                    //Debug.Log("“ž’B");
                    
                    Instantiate(wall, pos, Quaternion.identity);
                }
                else if (this.field[x, y] == 1)
                {
                    Instantiate(path, pos, Quaternion.identity);
                }
            }
        }

        List<(int, int)> proposed_pos = new List<(int, int)> ();
        for (int x = 0; x < this.field.GetLength(0); x++)
        {
            for (int y = 0; y < this.field.GetLength(1); y++)
            {
                if (this.field[x, y] == 0) { continue; }

                int wall_direction = 0;
                if (y + 2 < this.field.GetLength(1)) { if (this.field[x, y + 1] == 0) { wall_direction++; } }
                if (x + 2 < this.field.GetLength(0)) { if (this.field[x + 1, y] == 0) { wall_direction++; } }
                if (y - 2 > 0) { if (this.field[x, y - 1] == 0) { wall_direction++; } }
                if (x - 2 > 0) { if (this.field[x - 1, y] == 0) { wall_direction++; } }

                if (wall_direction == 3) { proposed_pos.Add((x, y)); }
            }
        }

        proposed_pos = proposed_pos.OrderBy(i => Guid.NewGuid()).ToList();

        Vector3 start_pos = new Vector3(proposed_pos[0].Item1 * 3, proposed_pos[0].Item2 * 3, 0);
        Debug.Log(string.Format("start_pos : {0}", start_pos));
        
        Vector3 goal_pos = new Vector3(proposed_pos[1].Item1 * 3, proposed_pos[1].Item2 * 3, 0);
        Debug.Log(string.Format("goal_pos : {0}", goal_pos));

        player.transform.position = start_pos;
        goal.transform.position = goal_pos;

        /*for (int x = 0; x < this.field.GetLength(0); x++)
        {
            for (int y = 0; y < this.field.GetLength(1); y++)
            {
                if (this.field[x, y] == 0) { continue; }

                int number = UnityEngine.Random.Range(0, 10);

                if (number == 0)
                {
                    Vector3 pos = new Vector3(x * 3, y * 3, 0);
                    Instantiate(this.enemies[UnityEngine.Random.Range(0, this.enemies.Length)], pos, Quaternion.identity);
                }
            }
        }*/
    }

    private void Dig(int x, int y)
    {
        this.field[x, y] = 1;

        int[] dig_direction = { 1, 2, 3, 4 };
        dig_direction = dig_direction.OrderBy(i => Guid.NewGuid()).ToArray();
        Debug.Log(string.Format("x : {0} | y : {1}", x, y));

        for (int i = 0; i < dig_direction.Length; i++)
        {
            if (dig_direction[i] == 1)
            {
                if (y + 2 >= this.field.GetLength(1)) { continue; }

                if (this.field[x, y + 1] == 0 && this.field[x, y + 2] == 0)
                {
                    this.field[x, y + 1] = 1;
                    this.field[x, y + 2] = 1;

                    Dig(x, y + 2);
                }
            }
            else if (dig_direction[i] == 2)
            {
                if (x + 2 >= this.field.GetLength(0)) { continue; }

                if (this.field[x + 1, y] == 0 && this.field[x + 2, y] == 0)
                {
                    this.field[x + 1, y] = 1;
                    this.field[x + 2, y] = 1;

                    Dig(x + 2, y);
                }
            }
            else if (dig_direction[i] == 3)
            {
                if (y - 2 < 0) { continue; }

                if (this.field[x, y - 1] == 0 && this.field[x, y - 2] == 0)
                {
                    this.field[x, y - 1] = 1;
                    this.field[x, y - 2] = 1;

                    Dig(x, y - 2);
                }
            }
            else if (dig_direction[i] == 4)
            {
                if (x - 2 < 0) { continue; }

                if (this.field[x - 1, y] == 0 && this.field[x - 2, y] == 0)
                {
                    this.field[x - 1, y] = 1;
                    this.field[x - 2, y] = 1;

                    Dig(x - 2, y);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
