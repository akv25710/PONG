using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowersManager : MonoBehaviour {
    private static int initialMoney = 10000;
    private int price = 4000;
    
    public Button MovePaddleFastButton;
    public Button PaddleSizeButton;
    public Button IncreseBallSizeButton;
    public Button SlowBallSpeedButton;


    public static List<int> powerList = new List<int>();

    public void FastPaddle()
    {
        if (!powerList.Contains(0))
        {
            if (initialMoney < price) return;
            initialMoney -= price;
            MovePaddleFastButton.GetComponent<Image>().color = Color.red;
            powerList.Add(0);
        }
        else
        {
            initialMoney += price;
            MovePaddleFastButton.GetComponent<Image>().color = Color.white;
            powerList.Remove(0);
        }
    }
    public void SlowBall()
    {
        if (!powerList.Contains(1))
        {
            if (initialMoney < price) return;
            initialMoney -= price;
            SlowBallSpeedButton.GetComponent<Image>().color = Color.red;
            powerList.Add(1);
        }
        else
        {
            initialMoney += price;
            SlowBallSpeedButton.GetComponent<Image>().color = Color.white;
            powerList.Remove(1);
        }
    }

    public void IncreaseBallSize()
    {
        if (!powerList.Contains(2))
        {
            if (initialMoney < price) return;
            initialMoney -= price;
            IncreseBallSizeButton.GetComponent<Image>().color = Color.red;
            powerList.Add(2);
        }
        else
        {
            initialMoney += price;
            IncreseBallSizeButton.GetComponent<Image>().color = Color.white;
            powerList.Remove(2);
        }
    }


    public void IncreasePaddleLength()
    {
        if (!powerList.Contains(3))
        {
            if (initialMoney < price) return;
            initialMoney -= price;
            PaddleSizeButton.GetComponent<Image>().color = Color.red;
            powerList.Add(3);
        }
        else
        {
        
            initialMoney += price;
            PaddleSizeButton.GetComponent<Image>().color = Color.white;
            powerList.Remove(3);
        }
    }

}
