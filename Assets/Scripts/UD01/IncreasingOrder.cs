using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//EJERCICIO: Introducir 3 n�meros y detectar si se han introducido en orden creciente
//Necesito 3 variables p�blicas globales que me dejen introducir
// Detectar --> verdadero o falso y condicional


public class IncreasingOrder : MonoBehaviour
{

    //zona de variables globales
    public int FirstNumber = 0,
               SecondNumber = 0,
               ThirdNumber = 0;

    // Start is called before the first frame update
    void Start()
    {

        // Llamo al m�todo
        IsTheIncreasingOrder();
    }

    // creo el m�todo
    private void IsTheIncreasingOrder()
    {
        if (FirstNumber <= SecondNumber && SecondNumber <= ThirdNumber)
        {
            Debug.Log("Has introducido los n�meros en orden correcto de menor a mayor.");
        }
        else 
        {
            Debug.Log("El orden en el que has introducido los n�meros no es el correcto");
        } 
        
    }
}
