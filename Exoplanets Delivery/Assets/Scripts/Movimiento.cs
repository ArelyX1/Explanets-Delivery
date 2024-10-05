using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float movimientoFuerza = 5f;
    private float fuerzaSalto = 12f;
    private Rigidbody2D miCuerpoRigido;

    void Start()
    {
        miCuerpoRigido = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        miCuerpoRigido.velocity = new Vector2(movementX * movimientoFuerza, miCuerpoRigido.velocity.y);

        // Detectar entrada de salto
        if (Input.GetButtonDown("Jump") && Mathf.Abs(miCuerpoRigido.velocity.y) < 0.001f)
        {
            miCuerpoRigido.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }
    }
}