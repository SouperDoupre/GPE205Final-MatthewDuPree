using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public int rows;
    public int columns;
    public float lvlWidth = 50;
    public float lvlHeight = 50;
    private Rooms[,] lvl;
    public int lvlSeed;
    public bool isRandom;
    public bool MapOfTheDay;
  
    public GameObject RandomRoomPrefab()
    {
        return levelPrefabs[UnityEngine.Random.Range(0, levelPrefabs.Length)];
    }
    public int DateToInt(DateTime date)
    {
        return date.Year + date.Month + date.Day + date.Hour + date.Minute + date.Second + date.Millisecond;
    }
    public void GenerateLevel()
    {
        lvl = new Rooms[rows, columns];

        if (isRandom)
        {
            UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        }
        else if (MapOfTheDay)
        {
            lvlSeed = DateToInt(DateTime.Now);
        }
        else
        {
            UnityEngine.Random.InitState(lvlSeed);
        }
        for (int currentrow = 0; currentrow <rows; currentrow++)
        {
            for (int currentcol = 0; currentcol < columns; currentcol++)
            {
                float xPos = lvlWidth * currentcol;
                float zPos = lvlHeight * currentrow;
                Vector3 newPos = new Vector3(xPos, 0, zPos);

                GameObject tempLvlObj = Instantiate(RandomRoomPrefab(), newPos, Quaternion.identity) as GameObject;

                tempLvlObj.transform.parent = this.transform;

                tempLvlObj.name = "Level " + currentcol + " , " + currentrow;

                Rooms tempLvl = tempLvlObj.GetComponent<Rooms>();

                lvl[currentcol, currentrow] = tempLvl;

                if (currentrow == 0)
                {
                    tempLvl.doorNorth.SetActive(false);
                }
                else if (currentrow == rows - 1)
                {
                    Destroy(tempLvl.doorSouth);
                }
                else
                {
                    Destroy(tempLvl.doorNorth);
                    Destroy(tempLvl.doorSouth);
                }
                if(currentcol == 0)
                {
                    tempLvl.doorEast.SetActive(false);
                }
                else if(currentcol == columns - 1)
                {
                    Destroy(tempLvl.doorWest);
                }
                else
                {
                    Destroy(tempLvl.doorEast);
                    Destroy(tempLvl.doorWest);
                }
            }
        }
    }
}
