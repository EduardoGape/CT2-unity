using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public float activeTime = 2.0f; // O tempo em segundos que o objeto ficará ativo
    public float inactiveTime = 2.0f; // O tempo em segundos que o objeto ficará inativo

    public float timer;
    private bool isActive;

    void Start()
    {
        timer = 0f;
        isActive = false;
        gameObject.SetActive(isActive);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!isActive && timer > inactiveTime)
        {
            // Ativa o objeto após 'inactiveTime' segundos
            isActive = true;
            timer = 0f;
            gameObject.SetActive(true);
        }
        else if (isActive && timer > activeTime)
        {
            // Desativa o objeto após 'activeTime' segundos
            isActive = false;
            timer = 0f;
            gameObject.SetActive(false);
        }
    }
}
