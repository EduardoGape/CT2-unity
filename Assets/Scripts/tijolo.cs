using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tijolo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            float posx = transform.position.x;
            float posy = transform.position.y + 1;
            float posz = transform.position.z;
            transform.position = new Vector3(posx,posy,posz);
        }
    }
}
