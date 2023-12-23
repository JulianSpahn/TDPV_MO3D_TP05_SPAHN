using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_Rodolfo : MonoBehaviour
{
    //declaramos los componentes de Rodolfo
    private BoxCollider rodolfo_Collider;
    private Rigidbody rodolfo_rigidbody;
    //declaramos las variables de salto y velocidad de movimiento
    public float jump = 10f;
    public float speed = 10f;
    
    private void Start(){//inicializamos los componentes
        rodolfo_Collider = GetComponent<BoxCollider>();
        rodolfo_rigidbody = GetComponent<Rigidbody>();
    }

    private bool is_On_The_Floor(){//funcion que nos avisara si rodolfo esta en el piso
        float length = rodolfo_Collider.bounds.extents.y + 0.1f;
        return Physics.Raycast(transform.position, Vector3.down, length);
    }

    private void movement(){//fincion encargada del movimiento de Rodolfo
        float dirX = Input.GetAxisRaw("Horizontal");
        rodolfo_rigidbody.velocity = new Vector3(dirX * speed, rodolfo_rigidbody.velocity.y, 0f);
        if (Input.GetButtonDown("Jump") && is_On_The_Floor()){
            rodolfo_rigidbody.velocity = new Vector3(rodolfo_rigidbody.velocity.x, jump, 0f);
        }
    }

    private void Update(){//actualizamos constantemente el movimiento
        movement();
    }
}
