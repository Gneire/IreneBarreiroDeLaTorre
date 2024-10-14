using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//EJERCICIO: muestra los números impares entre el y al 100.
//Necesito un bucle que recorra números del 0 al 100 + un if que me selecciones los impares.
//(Par --> % 2 == 0) --> (impar % 2 != 0)

public class Odd : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        //llamo al método
        GetOddNumbersFrom0To100();
    }

    // creo el método
    private void GetOddNumbersFrom0To100()
    {
        //Variable local "i" Declaro,inicializo variable de incremento y contador; todo ya dentro del "for"
        //Añado el condicional para que me muestre sólo los impares

        for (int i = 0; i < 101; i++)
        {
            if (i % 2 != 0)
            {
                Debug.Log(i);
            }
        }
    }
}
