using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float pointA;
    public float pointB;
    public float speed = 5.0f;

    private float targetPosition;

    void Start()
    {
        targetPosition = pointA;
    }

    void Update()
    {
        MoveNPC();
    }

    void MoveNPC()
    {
        // Lembre-se de que estamos apenas movendo ao longo do eixo x
        Vector3 position = transform.position;
        position.x = Mathf.MoveTowards(position.x, targetPosition, speed * Time.deltaTime);
        transform.position = position;

        if (Mathf.Abs(transform.position.x - targetPosition) < 0.1f)
        {
            // Troca o alvo quando o NPC chega perto do ponto alvo
            targetPosition = (Mathf.Abs(targetPosition - pointA) < 0.1f) ? pointB : pointA;
        }
    }
}
