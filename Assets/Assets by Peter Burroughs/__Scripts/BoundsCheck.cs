using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{

[System.Flags] 
public enum eScreenLocs { // a 
onScreen = 0, // 0000 in binary (zero) 
offRight = 1, // 0001 in binary 
offLeft = 2, // 0010 in binary 
offUp = 4, // 0100 in binary 
offDown = 8 // 1000 in binary 
}



public enum eType { center, inset, outset };
[Header("Inscribed")] 
public eType boundsType = eType.center; // a 
public float radius = 1f;
public bool keepOnScreen = true;



[Header("Dynamic")] 
public eScreenLocs screenLocs = eScreenLocs.onScreen;
public bool isOnScreen = true;
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
    isOnScreen = true;

    // Restrict the X position to camWidth 
    if (pos.x > camWidth + checkRadius) {

        pos.x = camWidth + checkRadius;
        
        isOnScreen = false; 
        // e 

        } 

    if (pos.x < -camWidth - checkRadius) { // e 

        pos.x = -camWidth - checkRadius;
        
        isOnScreen = false; 
        // e 

        }

    // Restrict the Y position to camHeight 
    if (pos.y > camHeight + checkRadius) { // e 

        pos.y = camHeight + checkRadius;
        
        isOnScreen = false; // e 

        } 

    if (pos.y < -camHeight -checkRadius) { // e 

        pos.y = -camHeight - checkRadius;
        
        isOnScreen = false; // e 

        } 

    if ( keepOnScreen && !isOnScreen ) {
            transform.position = pos; 
            isOnScreen = true;
            }

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
