using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Zona de variables globales
    [Header("Instantiate")]
    [SerializeField]
    private GameObject _enemyPrefab; //objeto que voy a instanciar
    [SerializeField]
    private Transform[] _posRotEnemy; //Array de la transform para las posiciones
    [SerializeField]
    private float _timeBetweenEnemies; //para tiempo entre la aparición de los enemigos

    private void Start()
    {
        InvokeRepeating("CreateEnemies", _timeBetweenEnemies, _timeBetweenEnemies);
    }

    private void CreateEnemies()
    {
        //saco aleatorio un número entero entre el 0 y la longitud del "Array"
        int n = Random.Range (0, _posRotEnemy.Length);
        Instantiate(_enemyPrefab, _posRotEnemy[n].position, _posRotEnemy[n].rotation);
    }
}
