using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Button playButton; 


    public void PlayGame()
    {
        if(!Global.InPlayMode)
        {
            Global.InPlayMode = true;
            playButton.gameObject.SetActive(false);
        }
    }
}
