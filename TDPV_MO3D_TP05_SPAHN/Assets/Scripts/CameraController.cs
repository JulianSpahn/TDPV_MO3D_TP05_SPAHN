using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //declaramos el objeto que sera el centro de atencion de la camara
    [SerializeField] GameObject rodolfo;
    //declaramos los limites de hasta donde nos puede seguir la camara
    public float left_Side_Limit, right_Side_Limit;

    void Update(){//actualizamos constante mente la posicion de la camara
        update_Camera_Position();
    }

    private void update_Camera_Position(){//funcion encargada de actualizar la posicion de la camara, teniendo en cuenta los limites de hasta donde nos acompaña esta ultima
        if (rodolfo != null){
            Vector3 newPosition = transform.position;
            newPosition.x = rodolfo.transform.position.x <= left_Side_Limit ? 0 : rodolfo.transform.position.x >= right_Side_Limit ? right_Side_Limit : rodolfo.transform.position.x;
            newPosition.y = rodolfo.transform.position.y;
            transform.position = newPosition;
        }
    }
}
