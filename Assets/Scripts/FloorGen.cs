using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloorGen : MonoBehaviour
{

    public GameObject player;
    public GameObject[] floors;
    float floorWidth;
    float screenHalfWidth;
    int floorCount = 3;
    float offSet;
    int currFloor = 1;
    int prevFloor = 0;

    GameObject wheel;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfWidth = (Camera.main.aspect * Camera.main.orthographicSize)*2;
        floorWidth = floors[0].transform.localScale.x;
        for(int i = 0 ; i < floorCount ; i++){
            floors[i].transform.localScale = new Vector3(screenHalfWidth, 1, 0);
            floors[i].transform.position = new Vector3(screenHalfWidth*(i-1), -2, 0);
        }
        offSet = floorWidth*3;

        wheel = player.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float relPos =  wheel.transform.position.x - floors[currFloor].transform.position.x + floorWidth/2;
        if(relPos > floorWidth){
            prevFloor = mod(currFloor-1, floorCount);
            floors[prevFloor].transform.Translate(new Vector3(offSet, 0, 0),Space.World);
            currFloor = mod(currFloor+1, floorCount);
        }else if(relPos < 0){
            prevFloor = mod(currFloor+1, floorCount);
            floors[prevFloor].transform.Translate(new Vector3(-offSet, 0, 0),Space.World);
            currFloor = mod(currFloor-1, floorCount);
        }
        //Debug.Log(currFloor);
    }

    int mod(int a, int b){
        return (b + (a%b))%b;
    }

}
