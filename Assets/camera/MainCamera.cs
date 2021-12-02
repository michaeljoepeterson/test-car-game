using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] GameObject followPlayer;
    [SerializeField] float CameraOffset = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();   
    }

    void FollowPlayer()
    {
        transform.position = followPlayer.transform.position - new Vector3(0,0,CameraOffset);
    }
}
