using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//EJERCICIO: muestra los números pares ENTRE el 0 y al 100 (no incluyen ni el 0 ni el 100).
//Necesito un bucle que recorra números del 1 al 99 + un if que me selecciones los pares.
// pares--> % 2 =0 0

public class Even : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //llamo al método
        GetEvenNumbersFrom1To99();
    }

    // creo el método
    private void GetEvenNumbersFrom1To99()
    {
        //Variable local "i" Declaro e inicializo variable de incremento y contador; todo ya dentro del "for"
        //Añado el condicional para que me muestre sólo los impares

        for (int i = 1; i < 100; i++)
        {
            if (i % 2 == 0)
            {
                Debug.Log(i);
            }
        }
    }
}