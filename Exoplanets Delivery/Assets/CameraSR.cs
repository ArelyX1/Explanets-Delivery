using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSR : MonoBehaviour
{
    public GameObject Target; // El objeto que la cámara sigue
    public float upperLimitY; // Límite superior para la posición Y de la cámara
    public float lowerLimitY; // Límite inferior para la posición Y de la cámara
    public float upperLimitX; // Límite superior para la posición X de la cámara
    public float lowerLimitX; // Límite inferior para la posición X de la cámara

    // Update is called once per frame
    void Update()
    {
        // Obtener la nueva posición Y, limitada por upperLimitY y lowerLimitY
        float targetY = Mathf.Clamp(Target.transform.position.y, lowerLimitY, upperLimitY);
        
        // Obtener la nueva posición X, limitada por upperLimitX y lowerLimitX
        float targetX = Mathf.Clamp(Target.transform.position.x, lowerLimitX, upperLimitX);
        
        // Establecer la posición de la cámara, manteniendo la posición Z y usando targetX y targetY
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}