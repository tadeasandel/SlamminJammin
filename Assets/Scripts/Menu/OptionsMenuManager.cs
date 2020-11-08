using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenuManager : MonoBehaviour
{
    GameObject pauseMenu;
    GameObject MenuControls;
    public Image MenuControlsImage1;
    public Image MenuControlsImage2;
    public float tutorialwaitTime;
    public KeyCode keyForPause;
    public List<Image> btn;
    bool showMenu;
    public GameObject backButton;
    bool zobrazenSipky;
    // Start is called before the first frame update
    private void Awake()
    {
        showMenu = false;
        MenuControls = GameObject.Find("Menu_Controls");
        pauseMenu = GameObject.Find("PauseMenu");
        MenuControlsImage1 = GameObject.Find("Menu_ControlsImage1").GetComponent<Image>();
        MenuControlsImage2 = GameObject.Find("Menu_ControlsImage2").GetComponent<Image>();
        zobrazenSipky = false;
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    void Start()
    {

        pauseMenu.SetActive(false);

        StartCoroutine(Tutorial(tutorialwaitTime, 1, 0));
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyForPause) && showMenu)
        {
            pauseMenu.SetActive(true);
            PauseGame();
            showMenu = false;

        }

    }
    public void Resume()
    {
        if (zobrazenSipky==false)
        {   
            ResumeGame();
        pauseMenu.SetActive(false);
        showMenu = true;

        }
     
    }
    public void exit()
    {
        if (zobrazenSipky == false)
        {
            Application.Quit();
        }
    }
    public void Return()
    {
        if (zobrazenSipky == false)
        {
            SceneManager.LoadScene("MainGame");
        }
    }
    public void controlsMenu()
    {
        if (zobrazenSipky == false)
        {
            pauseMenu.SetActive(false);
            MenuControls.SetActive(true);
            backButton.SetActive(true);
            MenuControlsImage1.color = new Color(MenuControlsImage1.color.r, MenuControlsImage1.color.g, MenuControlsImage1.color.b, 1);
            MenuControlsImage2.color = new Color(MenuControlsImage2.color.r, MenuControlsImage2.color.g, MenuControlsImage2.color.b, 1);
            zobrazenSipky = true;
        }
    }
    public void decontrolMenu()
    {
        backButton.SetActive(false);
        MenuControls.SetActive(false);
        zobrazenSipky = false;
        pauseMenu.SetActive(true);

    }


    IEnumerator Tutorial(float timewait, float startValue, float endValue)
    {
        yield return new WaitForSeconds(timewait);
        float currentValue = startValue;
            Debug.LogError(currentValue);
        while (currentValue >= endValue)
        {
            currentValue -= Time.deltaTime;
            MenuControlsImage1.color = new Color(MenuControlsImage1.color.r, MenuControlsImage1.color.g, MenuControlsImage1.color.b, currentValue);
            MenuControlsImage2.color = new Color(MenuControlsImage2.color.r, MenuControlsImage2.color.g, MenuControlsImage2.color.b, currentValue);

            yield return null;
        }
        MenuControls.SetActive(false);
        showMenu = true;
    }

    
}
