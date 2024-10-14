using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//EJERCICIO: introducir 3 números y que aparezcan en la pantalla de mayor a menor.
//Necesito 3 variables globales, públicas para introducir números
//3 variables locales posición de menor a mayor
//condicional 

public class FromLargestToSmallest : MonoBehaviour
{
    //zona variables globales
    public int NumberOne = 0,
               NumberTwo = 0,
               NumberThree = 0;

    void Start()
    {
        //llamo al método
        GetNumbersFromLargestToSmallest();
    }

    // creo el método
    private void GetNumbersFromLargestToSmallest()
    {
        //variables locales
        int FirstNumber,
            SecondNumber,
            LastNumber;

        //Busco el primer número y combino las otras posibilidades

        if (NumberOne >= NumberTwo && NumberOne >= NumberThree)
        {
            FirstNumber = NumberOne;

            if (NumberTwo >= NumberThree)
            {
                SecondNumber = NumberTwo;
                LastNumber = NumberThree;
            }
            else
            {
                SecondNumber = NumberThree;
                LastNumber = NumberTwo;
            }
        }
        else if (NumberTwo >= NumberThree && NumberTwo >= NumberOne)
        {
            FirstNumber = NumberTwo;

            if (NumberThree >= NumberOne)
            {
                SecondNumber = NumberThree;
                LastNumber = NumberOne;
            }
            else
            {
                SecondNumber = NumberOne;
                LastNumber = NumberThree;
            }

        }
        else
        {
            FirstNumber = NumberThree;

            if (NumberTwo >= NumberOne)
            {
                SecondNumber = NumberTwo;
                LastNumber = NumberOne;
            }
            else
            {
                SecondNumber = NumberOne;
                LastNumber = NumberTwo;
            }

        }
        Debug.Log("El orden es: " + FirstNumber + "," + SecondNumber + "," + LastNumber);
    }
}

