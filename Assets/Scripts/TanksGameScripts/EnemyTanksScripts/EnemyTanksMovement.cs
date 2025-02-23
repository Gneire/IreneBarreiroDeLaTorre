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
        //para buscar al "player" seg�n su etiqueta
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
        GetPlayer(); //si no, llamo al m�todo que le persigue
    }

    //creo el m�todo para perseguirlo y lo llamo en el "Update()"
    private void GetPlayer()
    {
       //para que el destino del agente de navegaci�n sea la posici�n del "player"
        _agent.SetDestination(_player.transform.position);
    }
}
