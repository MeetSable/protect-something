using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class PlayerController : MonoBehaviour
{

    public float speed = 30;
    float screenHalfWidth;
    float radius;
    float inputX=0;
    float moved = 0;


    // Start is called before the first frame update
    void Start()
    {
        radius = transform.localScale.x/2f;
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + radius;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void FixedUpdate(){
        if(Input.GetMouseButton(0)){
            //Debug.Log("pressed");
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            inputX = (mousePosition.x-transform.position.x)/screenHalfWidth;
            //Debug.Log(inputX);
            
        }else{
            //Debug.Log("not pressed");
            inputX=Mathf.Lerp(inputX,0,.0005f);
        }
        float velocity = inputX * speed;
        moved = Mathf.Lerp(moved,velocity * Time.fixedDeltaTime, 1f);
        transform.Translate(new Vector2(1,0) * moved,Space.World);       
        Vector3 rotation = transform.eulerAngles;
        rotation.z -= Mathf.Rad2Deg * moved/radius;
        transform.eulerAngles = rotation;
    }

    void LateUpdate(){        
    }

    
}
