using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VRTK;

public class LightboxManager : MonoBehaviour
{
    private int activeLighbox;
    private readonly string[,] lightboxes = new string[2,6]{ { "Materials/Sala_RV", "Materials/Sala_Redes", "Materials/Sala_ArqComp", "" ,"", "Materials/Sala_Agil" }, { "Materials/Corredor_RV", "Materials/Corredor_Redes", "Materials/Corredor_ArqComp", "Materials/Corredor_Meio", "Materials/Corredor_Agil2", "Materials/Corredor_Agil1" } }; 


    public GameObject LeftControllerPointer;
    public GameObject RightControllerPointer;

    public GameObject direitaTarget;
    public GameObject esquerdaTarget;
    public GameObject cimaTarget;
    public GameObject baixoTarget;

    private VRTK_Pointer LeftPointer;
    private VRTK_Pointer RightPointer;

    string direction;
    
    public void Start()
    {
        activeLighbox = 6;
        LeftPointer = LeftControllerPointer.GetComponent<VRTK_Pointer>();
        RightPointer = RightControllerPointer.GetComponent<VRTK_Pointer>();
        direction = "";
        SwitchTargets();
        BroadcastMessage("SkyboxUpdated");
    }

    public void DoSwitchLightbox() {
        RegisterDirection();
        if(direction != "") StartCoroutine(SwitchAndBlink());
    }
    void SwitchLightbox() {
        int nextLightbox;
        switch (direction) {
            case "direita":
                nextLightbox = activeLighbox + 1;
                break;
            case "esquerda":
                nextLightbox = activeLighbox - 1;
                break;
            case "frente":
                nextLightbox = activeLighbox - 6;
                break;
            case "tras":
                nextLightbox = activeLighbox + 6;
                break;
            default:
                nextLightbox = activeLighbox;
                break;  
        }

        int col = nextLightbox % 6;
        int line = (int)nextLightbox / 6;
        RenderSettings.skybox = Resources.Load<Material>(lightboxes[line,col]);
        BroadcastMessage("SkyboxUpdated");
        activeLighbox = nextLightbox;

        DynamicGI.UpdateEnvironment();
    }

    IEnumerator SwitchAndBlink() {
        GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 0.5f);
        yield return new WaitForSecondsRealtime(0.5f);

        SwitchLightbox();
        SwitchTargets();
        GetComponent<VRTK_HeadsetFade>().Unfade(0.5f);
    }

    public void RegisterDirection() {
        if (LeftPointer.pointerRenderer) {
            if (LeftPointer.pointerRenderer.GetDestinationHit().collider) {

                direction = LeftPointer.pointerRenderer.GetDestinationHit().collider.name;
                return;
            }
        }

        if (RightPointer.pointerRenderer)
        {
            if (RightPointer.pointerRenderer.GetDestinationHit().collider)
            {
                direction = RightPointer.pointerRenderer.GetDestinationHit().collider.name;
                return;
            }
        }

        direction = "";
    }

    public void SwitchTargets() {
        int col = activeLighbox % 6;
        int line = (int)activeLighbox / 6;

        if (col + 1 < 6)
        {
            direitaTarget.SetActive(lightboxes[line, col + 1] != "");
        }
        else {
            direitaTarget.SetActive(false);
        }
        if (col - 1 > -1)
        {
            esquerdaTarget.SetActive(lightboxes[line, col - 1] != "");
        }
        else
        {
            esquerdaTarget.SetActive(false);
        }

        if (line + 1 < 2)
        {
            baixoTarget.SetActive(lightboxes[line+1, col] != "");
        }
        else
        {
            baixoTarget.SetActive(false);
        }

        if (line - 1 > -1) {
            cimaTarget.SetActive(lightboxes[line - 1, col] != "");
        }
        else
        {
            cimaTarget.SetActive(false);
        }

    }


}
