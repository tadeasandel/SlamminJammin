using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI text_Newgame;
    public TextMeshProUGUI text_pressButton;
    public GameObject warning_text;
    float posX;
    float posY;
    int clickNumber;

    public List<Image> button;
    public List<TextMeshProUGUI> button_text;
    protected bool firstStart;
 
    void Start()
    {
        firstStart = true;

        for (int i = 0; i < 3; i++)
        {
            button[i].color = new Color(button[i].color.r, button[i].color.g, button[i].color.b, 0);
            button_text[i].alpha = 0;
        }
    }

   public void Button_start()
    {
        button[0].color = Color.Lerp(Color.white, Color.clear, 1);
        button_text[0].alpha = 0;
    }
    public void Button_Option_click()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void Button_Option_pointer()
    {
        warning_text.SetActive(true);
    }
    public void Button_Option_pointer_exit()
    {
        warning_text.SetActive(false);

    }
    public void Button_Quit()
    {
       
        generator();
        button[2].transform.localPosition = Vector3.Lerp(button[2].transform.localPosition, new Vector3(posX, posY,0),1);
        clickNumber++;
        if (clickNumber >=5)
        {
            Application.Quit();
        }
    }

    void Update()
  {
    if (Input.anyKeyDown)
    {
      if (Input.anyKeyDown && firstStart)
      {
        StartCoroutine(Fade());
      }
    }
  }
    void generator()
    {
        posX = Random.Range(-649, 470);
        posY = Random.Range(-301, 362);
        Debug.Log("posX" + posX + "posY" + posY);
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
        
            text_Newgame.alpha = currentValue;
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
                button_text[i].alpha = currentValue;
            }
            yield return null;
        }
        firstStart = false;
    }


}
