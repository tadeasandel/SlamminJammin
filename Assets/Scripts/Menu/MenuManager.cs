using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public List<Button> butons;
    public TextMeshProUGUI text_Newgame;
    public TextMeshProUGUI text_pressButton;
    public GameObject warning_text;
    float posX;
    float posY;
    int clickNumber;

    public List<Image> button;

  public Texture2D cursorTexture;

  public AudioSource mainSoundAudio;

  public AudioClip[] hahaSounds;
    public AudioClip click;
    public AudioClip sramot_sound;
    protected bool firstStart;
    protected bool runFade;
    void Start()
    {
    Cursor.SetCursor(cursorTexture,new Vector2(50,50), CursorMode.ForceSoftware);
        firstStart = true;
       
        for (int i = 0; i < 3; i++)
        {
            button[i].color = new Color(button[i].color.r, button[i].color.g, button[i].color.b, 0);
            butons[i].enabled = false;
        }
    }
    void PlayClick()
    {
        mainSoundAudio.PlayOneShot(click);

    }

   public void Button_start()
    {
        button[0].color = Color.Lerp(Color.white, Color.clear, 1);
        mainSoundAudio.PlayOneShot(hahaSounds[Random.Range(0,hahaSounds.Length)]);
    }
    public void Button_Option_click()
    {
        
        if (firstStart == false )
        {


            StartCoroutine(LoadsceneCorountine());
         
        }
       
    }
    public void soundPointer()
    {
        mainSoundAudio.PlayOneShot(sramot_sound);
    }
    public void Button_Option_pointer()
    {
        if (firstStart==false)
        {
            mainSoundAudio.PlayOneShot(sramot_sound);
            warning_text.SetActive(true);
        }
        
    }
    public void Button_Option_pointer_exit()
    {
        mainSoundAudio.Stop();
        warning_text.SetActive(false);

    }
    public void Button_Quit()
    {
        PlayClick();
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
        
        if (Input.anyKeyDown && runFade==false)
        {
          if (Input.anyKeyDown && firstStart)
          {
                    runFade = true;
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

    IEnumerator LoadsceneCorountine()
    {
        PlayClick();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainGame");
        // yield return null;



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
        for (int i = 0; i < butons.Count; i++)
        {
            butons[i].enabled = enabled;
        }
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
        firstStart = false;
    }


}
