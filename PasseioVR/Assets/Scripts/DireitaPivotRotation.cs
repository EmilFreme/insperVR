using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DireitaPivotRotation : MonoBehaviour
{
    public void SkyboxUpdated()
    {
        string skybox = RenderSettings.skybox.name;

        switch (skybox)
        {
            case "Corredor_RV":
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;

            case "Corredor_Redes":
            case "Corredor_ArqComp":
            case "Corredor_Agil2":
            case "Corredor_Agil1":
                transform.eulerAngles = new Vector3(0, 180, 0);
                break;
        }
    }
}
