using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{

public enum eType { center, inset, outset };
[Header("Inscribed")] 
public eType boundsType = eType.center; // a 
public float radius = 1f;



[Header("Dynamic")] 
public float camWidth; 
public float camHeight; 


void Awake() { 
    camHeight = Camera.main.orthographicSize; // b 
    camWidth = camHeight * Camera.main.aspect; // c 
    }


void LateUpdate () {


    float checkRadius = 0; 
    if (boundsType == eType.inset) checkRadius = -radius; 
    if (boundsType == eType.outset) checkRadius = radius;


    Vector3 pos = transform.position; 

    // Restrict the X position to camWidth 
    if (pos.x > camWidth + checkRadius) {

        pos.x = camWidth + checkRadius; // e 

        } 

    if (pos.x < -camWidth - checkRadius) { // e 

        pos.x = -camWidth - checkRadius; // e 

        }

    // Restrict the Y position to camHeight 
    if (pos.y > camHeight + checkRadius) { // e 

        pos.y = camHeight + checkRadius; // e 

        } 

    if (pos.y < -camHeight -checkRadius) { // e 

        pos.y = -camHeight - checkRadius; // e 

        } 

    transform.position = pos; 
}






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}