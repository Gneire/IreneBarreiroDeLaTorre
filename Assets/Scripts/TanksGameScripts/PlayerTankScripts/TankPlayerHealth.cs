using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TankPlayerHealth : MonoBehaviour
{
    //zona de variables globales
    [Header("Health")]
    [SerializeField]
    private float _maxHealth; //para la salud m�xima
    [SerializeField]
    private float _currentHealth; //para la salud actual
    [SerializeField]
    private float _damageEnemyShells; //para el da�o que hacen las bolas enemigas

    [Header("ProgressBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem _tankExplosion;
    [SerializeField]
    private ParticleSystem _shellExplosion;

    //para llamarla y acudir al m�todo p�blico "GameOver()" del otro "Script"
    [Header("GameOver")]
    [SerializeField]
    private GameManagerTanksScript _gameManager;


    private void Awake()
    {
        _currentHealth = _maxHealth; //M�xima vida al principio
        _lifeBar.fillAmount = 1.0f; //va de 0 a 1 en la barra de la imagen en el Inspector
        //paro las explosiones al principio 
        _tankExplosion.Stop();
        _shellExplosion.Stop();


    }

    //hacemos un evento tipo "Trigger" para decirle que si la bala me toca,
    //tiene que restar a mis salud actual el da�o de la bala enemiga y 
    //decirle cuando muero
    private void OnTriggerEnter (Collider infoAccess)
    {
        if (infoAccess.CompareTag("EnemyShell"))
        {
            _shellExplosion.Play(); //cuando nos da la bala 
            _currentHealth -= _damageEnemyShells;
            _lifeBar.fillAmount = _currentHealth /_maxHealth;
            Destroy(infoAccess.gameObject);//las balas se destruyen al chocar  

            if (_currentHealth <= 0.0F) //si mi salud es menos o igual a cero 
            {

                _tankExplosion.Play();
                Death(); //llamo al m�todo de la muerte
            }
        
        }
    }
    private void Death()
    {
          
         //cuando morimos mi tanque se destruye totalmente y que tarde 1 segundo para verlo
         Destroy(gameObject, 1.0f);
         _gameManager.GameOver();
       
        
    }

}
