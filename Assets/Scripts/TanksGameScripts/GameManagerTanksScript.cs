using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTanksScript : MonoBehaviour
{
 
    //Zona de variables globales
    [Header("GameOver")]
    [SerializeField]
    private GameObject _panelGameOver;
    [SerializeField]
    private EnemyManager _enemyManager;

    //creo el método para gestionar el "GameOver"
    public void GameOver()
    {
        _enemyManager.enabled = false;//desactivo que se sigan instanciando los enemigos
        _panelGameOver.SetActive(true);//activo el GameObject del panel
    }
    //creo método para recargar la escena desde fuera
    public void LoadSceneLevel()
    {
        SceneManager.LoadScene(1);
    }
}
