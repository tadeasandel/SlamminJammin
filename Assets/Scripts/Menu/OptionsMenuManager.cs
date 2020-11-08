using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    GameObject pauseMenu;
    GameObject MenuControls;
    public Image MenuControlsImage;
    public float tutorialwaitTime;
    public KeyCode keyForPause;
    public List<Image> btn;
    // Start is called before the first frame update
    private void Awake()
    {
        MenuControls = GameObject.Find("Menu_Controls");
        pauseMenu = GameObject.Find("PauseMenu");
        MenuControlsImage = GameObject.Find("Menu_Controls").GetComponent<Image>();
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

        //pauseMenu.SetActive(false);
        StartCoroutine(Tutorial(tutorialwaitTime, 1, 0));
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyForPause))
        {


        }

    }
    void DisableMenuObject()
    {
        for (int i = 0; i < btn.Count; i++)
        {
            btn[i].gameObject.SetActive(false);

        }
    }
    IEnumerator ShowMenu(float timewait, float startValue, float endValue)
    {
        yield return new WaitForSeconds(timewait);
        float currentValue = startValue;
        Debug.LogError(currentValue);
        while (currentValue >= endValue)
        {
            currentValue -= Time.deltaTime;
            MenuControlsImage.color = new Color(MenuControlsImage.color.r, MenuControlsImage.color.g, MenuControlsImage.color.b, currentValue);


            yield return null;
        }
        MenuControls.SetActive(false);
    }

    IEnumerator Tutorial(float timewait, float startValue, float endValue)
    {
        yield return new WaitForSeconds(timewait);
        float currentValue = startValue;
            Debug.LogError(currentValue);
        while (currentValue >= endValue)
        {
            currentValue -= Time.deltaTime;
            MenuControlsImage.color = new Color(MenuControlsImage.color.r, MenuControlsImage.color.g, MenuControlsImage.color.b, currentValue);

            
            yield return null;
        }
        MenuControls.SetActive(false);
    }

    
}
