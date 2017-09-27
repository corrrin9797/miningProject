﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameScript : MonoBehaviour {

    //"By the deadline, create a game that functions the same as the previous part, with the following additions:"
    // and later, it says:
    // "Instead of what's described previously,"
    // without specifying what previously was being struck from what to include.
    // nothing about whether to include a global suppy of ore, for instance.
    // I'll assume the basic concept of mining is the same, but I'll be replacing stuff wherever I can:
    // points replaces player-gathered ore, ore being clicked replaces ore being given.
    
    public int miningSpeed=3; 
    public static int bronzePoints = 1;
    public static int silverPoints = 10;
    public static int goldPoints = 100;
    public static int points;
    public static int bronzeOre;
    public static int silverOre;
    public static int goldOre;
    int nextMine; //Tracks when the next ore will be mined by adding miningSpeed to it whenever ore is mined.

    //a location in the world
    Vector3 cubePosition;
    //initializes a cube
    public GameObject cubePrefab;

    GameObject currentCube;

    float xPosition, yPosition;


	// Use this for initialization
	void Start () {
        points = 0;
        bronzeOre = 0;
        silverOre = 0;
        goldOre = 0;
        nextMine = miningSpeed;
        //                         x, y, z
        cubePosition = new Vector3(0, 0, 0);
        xPosition = -10;
        yPosition = 4;
	}
	


	// Update is called once per frame
	void Update () {
        if (Time.time > nextMine){
            nextMine += miningSpeed;
            //I didn't know whether the mining statements were exclusive, if they ran in order or if only one could happen.
            //I also didn't know which had priority if they were exclusive
            //I made it so as only one could happen.
            if (silverOre==2 && bronzeOre==2){
                goldOre++;
                xPosition += 2;
                if (xPosition > 8)
                {
                    yPosition -= 2;
                    xPosition = -8;
                }
                cubePosition = new Vector3(xPosition, yPosition, 0);

                //                                    Quaternion, as of right now, is a magic word.
                currentCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                currentCube.GetComponent<Renderer>().material.color = Color.yellow;
                currentCube.AddComponent<goldScript>();
            }
            else if (bronzeOre < 4){
                bronzeOre++;
                xPosition += 2;
                if (xPosition > 8){
                    yPosition -= 2;
                    xPosition=-8;
                }
                cubePosition = new Vector3(xPosition, yPosition, 0);

                //                                    Quaternion, as of right now, is a magic word.
                currentCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                currentCube.GetComponent<Renderer>().material.color = Color.red;
                currentCube.AddComponent<bronzeScript>();
                
                
            }
            else{ //No need for an if statement here, there's no distance between <4 and 4
                silverOre++;
                xPosition += 2;
                if (xPosition > 8)
                {
                    yPosition -= 2;
                    xPosition = -8;
                }
                cubePosition = new Vector3(xPosition, yPosition, 0);

                //                                    Quaternion, as of right now, is a magic word.
                currentCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                currentCube.GetComponent<Renderer>().material.color = Color.white;
                currentCube.AddComponent<silverScript>();
            }
            print("You have " + points + " points");
            print("Bronze: " + bronzeOre + " Silver: " + silverOre + " Gold: " + goldOre);
        }
        
	}
    
}
