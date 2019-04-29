using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text desc;
    public Text header;


    public void SkyboxUpdated()
    {
        gameObject.SetActive(true);
        switch (RenderSettings.skybox.name) {
            case "Corredor_RV":
                header.text = "Bem vindo ao passeio virtual do quarto andar. ";
                desc.text = "Para navegar aponte o controle para as setas no chão e ative o gatilho do controle.";
                break;

            case "Sala_RV":
                header.text = "Realidade Virtual e Jogos Digitais";
                desc.text = "São ministradas as matérias de Realidade Virtual assim como Jogos Digitais. \n O laborátorio fornece toda a infra necessária como headsets de realidade virtual e aumentada.";
                break;


            case "Sala_Redes":
                header.text = "Redes e Supercomputação";
                desc.text = "São ministradas as matérias de Redes, Supercomputação e Cloud. \n Contamos com kits de Intel NUC, para que os alunos compreendam e criem uma infraestrutura de sistemas cloud.";
                break;
            default:
                gameObject.SetActive(false);
                break;
        }
    }
}
