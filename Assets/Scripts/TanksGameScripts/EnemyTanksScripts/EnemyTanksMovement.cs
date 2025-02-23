using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTanksMovement : MonoBehaviour
{
    //Zona de variables globales
    //el objetivo a perseguir (esta vez cojo todo el "GameObject" entero)
    [SerializeField]
    private GameObject _player;
    //para coger el componente "NavMeshAgent" en el "Awake()"
    private NavMeshAgent _agent; 

    private void Awake()
    {
        //para buscar al "player" según su etiqueta
        //utilizo el "FindGameObjectWithTag()"
        _player = GameObject.FindGameObjectWithTag("PlayerTank");
        _agent = GetComponent<NavMeshAgent>();  
        
    }

  
    void Update()
    {
       if (_player == null) //si no hay "player"
        {
            return; //no sigo
        }
        GetPlayer(); //si no, llamo al método que le persigue
    }

    //creo el método para perseguirlo y lo llamo en el "Update()"
    private void GetPlayer()
    {
       //para que el destino del agente de navegación sea la posición del "player"
        _agent.SetDestination(_player.transform.position);
    }
}
