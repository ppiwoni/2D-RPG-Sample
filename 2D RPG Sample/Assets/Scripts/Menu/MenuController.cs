using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public RawImage rawImage;
    float offset;
    // Use this for initialization
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {

        offset += Time.deltaTime * 0.1f;
        rawImage.uvRect = new Rect(offset, 0f, 1f, 1f);


    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
