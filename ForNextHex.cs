using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForNextHex : MonoBehaviour
{
    public GameObject firstPanIra1;
    public GameObject mainIraPan1;
    public GameObject panelLose1;
    public GameObject panelWin1;

    void OnMouseUpAsButton()
    {
        firstPanIra1.SetActive(false);
        mainIraPan1.SetActive(true);
        panelLose1.SetActive(false);
        panelWin1.SetActive(false);
       
    }
}
