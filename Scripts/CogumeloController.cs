using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogumeloController : MonoBehaviour
{
    private float direction = 1.0f;
    private BoxCollider2D boxCollider;
    public int state;
    public float time;

    void Start()
    {
        transform.Translate(0, 1.0f, 0);
        Invoke("ActivedBoxCollider", 0.1f);
    }
    void ActivedBoxCollider()
    {
        boxCollider = GetComponent<BoxCollider2D>(); // Obter a referência ao BoxCollider2D
        boxCollider.enabled = true; // Ativar o BoxCollider2D
    }

    void Update()
    {
        transform.Translate((2.0f*direction)*Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Direction"){
            direction = -direction;
        }
        if(collision.gameObject.tag == "Player" && state == 0){
            PlayerController.CogumelosCountSize += 0.5f;
            Destroy(gameObject);
        }
    }
}
