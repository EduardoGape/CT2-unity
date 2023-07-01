using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlock : MonoBehaviour
{
    public Color originalColor;
    public GameObject CogumeloPrefeb;
    public float darkenAmount = 0.5f; // Valor entre 0 e 1 para determinar o quanto a cor será escurecida
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float force;
    private bool activated;
    private Vector3 initialPosition;

    public float resetDelay = 0.5f; // Atraso para chamar a função ResetBlockPosition

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = 0f; // Desativa a gravidade do objeto
        activated = true;

        initialPosition = transform.position; // Salva a posição inicial do objeto
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && activated)
        {
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            Invoke("ResetBlockPosition", resetDelay); // Chama a função ResetBlockPosition após o atraso especificado
        }
    }

    void ResetBlockPosition()
    {
        Instantiate(CogumeloPrefeb, transform.position, Quaternion.identity);
        activated = false; // Desativa temporariamente o bloco
        transform.position = initialPosition;
        rb.simulated = false; // Desativa o Rigidbody2D do objeto
        spriteRenderer.color = DarkenColor(spriteRenderer.color, darkenAmount);
    }

    Color DarkenColor(Color originalColor, float darkenAmount)
    {
        float r = Mathf.Lerp(originalColor.r, 0f, darkenAmount);
        float g = Mathf.Lerp(originalColor.g, 0f, darkenAmount);
        float b = Mathf.Lerp(originalColor.b, 0f, darkenAmount);
        return new Color(r, g, b, originalColor.a);
    }
}
