using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI text_novahra;
    public TextMeshProUGUI text_pressButton;
  
    public List<Image> button;
    protected bool prvnistart;
 
    void Start()
    {
        prvnistart = true;

        for (int i = 0; i < 3; i++)
        {
            button[i].color = new Color(button[i].color.r, button[i].color.g, button[i].color.b, 0);
        }
    }

  void Update()
  {
    if (Input.anyKeyDown)
    {
      if (Input.anyKeyDown && prvnistart)
      {
        StartCoroutine(Fade());
      }
    }
  }
        
    IEnumerator Fade()
    {
        yield return StartCoroutine(FadeOut(1, 0));
        StartCoroutine(FadeIn(0, 1));


    }

    IEnumerator FadeOut(float startValue,float endValue)
    {
        Debug.LogError("probehlo_spusteni");
       
        float currentValue = startValue;
        Debug.LogError(currentValue);
        while (currentValue >=endValue)
        {
            currentValue -= Time.deltaTime;
        
            text_novahra.alpha = currentValue;
            Debug.LogError("probehlo");
            text_pressButton.alpha = currentValue;
            yield return null;
        }
       
       
        
    }
    IEnumerator FadeIn(float startValue, float endValue)
    {
        float currentValue = startValue;

        while (currentValue <= endValue)
        {
            currentValue += Time.deltaTime;

            for (int i = 0; i < 3; i++)
            {
                button[i].color = new Color(button[i].color.r, button[i].color.g, button[i].color.b, currentValue);

            }
            yield return null;
        }
        prvnistart = false;
    }

}
