using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    //instanciamos el colider de la meta
    Collider goal_Collider;

    private void Start(){//inicializamos el colider de la meta
        goal_Collider = GetComponent<Collider>();
    }

    public bool is_Rodolfo_Inside(GameObject rodolfo){//funcion encargada de avisar si rodolfo encaja en la meta
        Collider rodolfo_Collider = rodolfo.GetComponent<Collider>();
        if (rodolfo_Collider == null){
            Debug.LogError("Both objects must have colliders.");
            return false;
        }
        return goal_Collider.bounds.Contains(rodolfo_Collider.bounds.min) && goal_Collider.bounds.Contains(rodolfo_Collider.bounds.max);
    }

    private void OnTriggerStay(Collider rodolfo){//funcion que dispara la escena de victoria si rodolfo esta dentro de la caja de la meta
        if (rodolfo.gameObject.CompareTag("Player")){
            if (is_Rodolfo_Inside(rodolfo.gameObject)){
                Debug.Log("Ganaste");
                rodolfo.gameObject.SetActive(false);
                SceneManager.LoadScene(1);
            }
        }
    }

}
