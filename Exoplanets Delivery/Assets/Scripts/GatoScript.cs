using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoScript : MonoBehaviour
{
    [SerializeField] float speed; // Velocidad del gato
    [SerializeField] float targetPosition; // Distancia mínima para detenerse
    [SerializeField] Transform playerTransform; // Transform del jugador
    [SerializeField] float headOffsetY; // Desplazamiento en el eje Y para apuntar a la cabeza

    Rigidbody2D myRigidbody2D;
    Animator myAnimator;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        TargetFollow();
        FlipSprite();
    }

    void TargetFollow()
    {
        // Calculamos la distancia al jugador (en general, no solo en X)
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget > targetPosition)
        {
            myAnimator.SetBool("Running", true);

            // Posición objetivo hacia la cabeza del jugador (X e Y)
            Vector2 targetPosition = new Vector2(
                target.position.x,                  // Posición en X del jugador
                target.position.y + headOffsetY     // Posición en Y de la cabeza del jugador
            );

            // Mover el Gato hacia la posición de la cabeza del jugador
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            myAnimator.SetBool("Running", false);
        }
    }

    void FlipSprite()
    {
        // Flipping: Determinamos si el Gato está a la izquierda o derecha del jugador
        if (playerTransform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (playerTransform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
