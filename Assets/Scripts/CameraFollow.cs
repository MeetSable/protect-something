using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    GameObject wheel;
    // Start is called before the first frame update
    void Start()
    {
        wheel = player.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(wheel.transform.position.x, transform.position.y, transform.position.z),0.5f);

        if(Input.GetMouseButton(1)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
