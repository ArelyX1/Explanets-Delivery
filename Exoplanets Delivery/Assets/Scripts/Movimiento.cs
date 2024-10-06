using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float movimientoFuerza = 3.5f;
    private float fuerzaSalto = 6f;
    private Rigidbody2D miCuerpoRigido;

    public Animator animator;

    void Start()
    {
        miCuerpoRigido = GetComponent<Rigidbody2D>();

        // Configura la fricción a cero
        Collider2D collider = GetComponent<Collider2D>();
        PhysicsMaterial2D noFrictionMaterial = new PhysicsMaterial2D();
        noFrictionMaterial.friction = 0f;
        noFrictionMaterial.bounciness = 0f;
        collider.sharedMaterial = noFrictionMaterial;
    }

    void Update()
    {
        float movementX = Input.GetAxisRaw("Horizontal");
        miCuerpoRigido.velocity = new Vector2(movementX * movimientoFuerza, miCuerpoRigido.velocity.y);

        animator.SetFloat("Movement", Mathf.Abs(movementX * movimientoFuerza));

        if (movementX < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (movementX > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(miCuerpoRigido.velocity.y) < 0.001f)
        {
            miCuerpoRigido.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
        }
    }
}