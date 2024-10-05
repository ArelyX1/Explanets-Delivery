using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float movimientoFuerza = 5f;
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
    }
}