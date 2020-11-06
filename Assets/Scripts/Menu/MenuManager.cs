using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MenuManager : MonoBehaviour
{
<<<<<<< Updated upstream
  void Start()
  {

  }
=======
    public TextMeshProUGUI text_novahra;
    public TextMeshProUGUI text_pressButton;
    public Image button;

   
    protected bool prvnistart;
    // Start is called before the first frame update
    void Start()
    {
        prvnistart = true;


    }
>>>>>>> Stashed changes

  void Update()
  {
    if (Input.anyKeyDown)
    {
<<<<<<< Updated upstream

    }
  }
=======
        if (Input.GetKeyDown(KeyCode.Escape)&&prvnistart)
        {
            StartCoroutine(Fade());
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
            // text_novahra
            text_novahra.alpha = currentValue;
            Debug.LogError("probehlo");
            text_pressButton.alpha = currentValue;
            yield return null;
        }
       
        //prvnistart = false;
        
    }
    IEnumerator FadeIn(float startValue, float endValue)
    {
        float currentValue = startValue;
        while (currentValue >= endValue)
        {
            currentValue += Time.deltaTime;
            
            button.color =  new Color(button.color.r, button.color.g, button.color.b, currentValue);
           
            yield return null;
        }

    }

>>>>>>> Stashed changes
}
