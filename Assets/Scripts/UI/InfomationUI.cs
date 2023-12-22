using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfomationUI : MonoBehaviour
{
    public Text projectName;
    public Text borderProjName;
    public Text credits;

    private void Start()
    {
        projectName.text = "Version-" 
            + Application.version + "@"
            + Application.companyName;
        borderProjName.text = projectName.text;
    }

}
