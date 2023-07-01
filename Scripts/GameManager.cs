using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject plant;
    public float targetY;
    public float speed = 1.0f;
    public float activeTime = 2.0f;
    public float inactiveTime = 2.0f;
    private float epsilon = 0.01f; // A margem de erro para a comparação

    private float timer;
    private bool isActive;
    private bool isMovingUp = true;
    private Vector3 initialPosition;

    void Start()
    {
        timer = 0f;
        isActive = false;
        initialPosition = plant.transform.position;
        plant.SetActive(isActive);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!isActive && timer > inactiveTime)
        {
            isActive = true;
            isMovingUp = true;
            timer = 0f;
            plant.SetActive(true);
        }
        else if (isActive && timer > activeTime)
        {
            isActive = false;
            timer = 0f;
            plant.SetActive(false);
        }

        if (plant.activeSelf)
        {
            float newY;
            if (isMovingUp)
            {
                newY = Mathf.Lerp(plant.transform.position.y, targetY, Time.deltaTime * speed);
                if (Mathf.Abs(plant.transform.position.y - targetY) < epsilon) // Verifique a diferença absoluta em vez de usar Approximately
                {
                    isMovingUp = false;
                }
            }
            else
            {
                newY = Mathf.Lerp(plant.transform.position.y, initialPosition.y, Time.deltaTime * speed);
                if (Mathf.Abs(plant.transform.position.y - initialPosition.y) < epsilon) // Verifique a diferença absoluta em vez de usar Approximately
                {
                    isMovingUp = true;
                }
            }

            plant.transform.position = new Vector3(plant.transform.position.x, newY, plant.transform.position.z);
        }
    }
}
