using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{

    public Text resultText;
    public float num1 = 0f;
    public float num2 = 0f;
    public string operation;

  
    public void iAddition()
    {
        num1 = float.Parse(resultText.text);
        operation = ("+");
        resultText.text = "";
    }

    public void iSubtraction()
    {
        num1 = float.Parse(resultText.text);
        operation = ("-");
        resultText.text = "";
    }

    public void iDivision()
    {
        num1 = float.Parse(resultText.text);
        operation = ("/");
        resultText.text = "";
    }

    public void iMultiplication()
    {
        num1 = float.Parse(resultText.text);
        operation = ("*");
        resultText.text = "";
    }

    public void btndigit7()
    {
        if (resultText.text == Convert.ToString(0))
        {
            resultText.text = "7";
        }
        else
        {
            resultText.text = resultText.text + "7";
        }        
    }

    public void btndigit8()
    {
        if (resultText.text == Convert.ToString(0))
        {
            resultText.text = "8";
        }
        else
        {
            resultText.text = resultText.text + "8";
        }
    }

    public void btndigit9()
    {
        if (resultText.text == Convert.ToString(0))
        {
            resultText.text = "9";
        }
        else
        {
            resultText.text = resultText.text + "9";
        }
    }

    public void btndigit4()
    {
        if (resultText.text == Convert.ToString(0))
        {
            resultText.text = "4";
        }
        else
        {
            resultText.text = resultText.text + "4";
        }
    }

    public void btndigit5()
    {
        if (resultText.text == Convert.ToString(0))
        {
            resultText.text = "5";
        }
        else
        {
            resultText.text = resultText.text + "5";
        }
    }

    public void btndigit6()
    {
        if (resultText.text == Convert.ToString(0))
        {
            resultText.text = "6";
        }
        else
        {
            resultText.text = resultText.text + "6";
        }
    }

    public void btndigit3()
    {
        if (resultText.text == Convert.ToString(0))
        {
            resultText.text = "3";
        }
        else
        {
            resultText.text = resultText.text + "3";
        }
    }

    public void btndigit2()
    {
        if (resultText.text == Convert.ToString(0))
        {
            resultText.text = "2";
        }
        else
        {
            resultText.text = resultText.text + "2";
        }
    }

    public void btndigit1()
    {
        if (resultText.text == Convert.ToString(0))
        {
            resultText.text = "1";
        }
        else
        {
            resultText.text = resultText.text + "1";
        }
    }

    public void btndigit0()
    {
        if (resultText.text == Convert.ToString(0))
        {
            resultText.text = "0";
        }
        else
        {
            resultText.text = resultText.text + "0";
        }
      

    }

    public void EqualsOper()
    {
        float answer = 0f;
        num2 = float.Parse(resultText.text);

        if (operation =="+")
        {
            answer = num1 + num2;
            resultText.text = answer.ToString();
        }

        if (operation == "-")
        {
            answer = num1 - num2;
            resultText.text = answer.ToString();
        }

        if (operation == "*")
        {
            answer = num1 * num2;
            resultText.text = answer.ToString();
        }

        if (operation == "/")
        {
            answer = num1 / num2;
            resultText.text = answer.ToString();
        }


    }
    public void btnClear()
    {
        resultText.text = "0";
    }

    public void btnEClear()
    {
        resultText.text = "0";
        string f, s;

        f = Convert.ToString(num1);
        s = Convert.ToString(num2);

        f = "";
        s = "";
    }

    public void btnBackSpace()
    {
        if (resultText.text.Length > 0)
        {
            resultText.text = resultText.text.Remove(resultText.text.Length - 1, 1);

            
        }
        if (resultText.text == "")
        {
            resultText.text = "0";


        }
    }

    public void plusMinus()
    {
        float q = float.Parse(resultText.text);
        resultText.text = Convert.ToString(-1 * q);
    }

    //! is not
    public void Dec()
    {
        if (!resultText.text.Contains("."))
        {
            resultText.text = resultText.text + ".";
        }
    }

}
