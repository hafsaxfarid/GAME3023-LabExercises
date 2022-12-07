using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader llInstance;

    [SerializeField]
    Animator fadeController;

    [SerializeField]
    GameObject fadeCanvas;

    [SerializeField]
    int waitForSeconds = 1;

    [SerializeField]
    public bool nextLevel = false;

    private void Awake()
    {
        if (llInstance == null)
        {
            llInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(nextLevel == true)
        {
            fadeCanvas.gameObject.SetActive(true);
            StartCoroutine(StartSceneFade());
        }
    }

    IEnumerator StartSceneFade()
    {
        fadeController.SetTrigger("StartFade");

        yield return new WaitForSeconds(waitForSeconds);

        fadeCanvas.gameObject.SetActive(false);
        nextLevel = false;
    }
}
