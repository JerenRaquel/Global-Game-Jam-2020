using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillController : MonoBehaviour
{
    public Image fillBar;
    public bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        fillBar.fillAmount = 0;
    }

    public void IncreaseFill(float amount)
    {
        if(fillBar.fillAmount >= 1)
        {
            isDone = true;
            return;
        }
        fillBar.fillAmount += (amount / 100);
    }
}
