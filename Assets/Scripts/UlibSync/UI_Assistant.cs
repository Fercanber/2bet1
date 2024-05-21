using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class UI_Assistant : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private int characterIndex = 1;

    public void Awake()
    {
       audioSource = transform.Find("Wizzard").Find("Body").GetComponent<AudioSource>();   
       messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        transform.Find("message").Find("nextText").GetComponent<Button>().onClick.AddListener(() =>
        {
            if(textWriterSingle != null && textWriterSingle.isActive())
            {
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                string[] messageArray = new string[]
                {
                 "En el rec�ndito Hizdharr Village, se alza una mazmorra de la cual ning�n mago ha logrado salir victorioso.",
                 "Oculta en sus entra�as se encuentra La Vara de Hizdharr, un objeto de poder inimaginable que concede a su poseedor sabidur�a y magia superiores a las de cualquier hechicero.",
                 "Dos magos de renombre, Prometheuss y Roosswall, llegaron al pueblo con la firme intenci�n de conquistar la mazmorra y reclamar la vara.",
                 "Al adentrarse en sus sombr�as galer�as, los senderos se bifurcan, llevando a Prometheuss y Roosswall por rutas divergentes.\r\n",
                 "Deber�s comunicarte con tu compa�ero para resolver los diferentes problemas, enigmas y acertijos que se interpondr�n en vuestro camino.",
                 "Estos enigmas y acertijos, se encontrar�n escondidos en cada nivel, por tanto deber�s primero encontrarlos para poder resolverlos.",
                 "!Buena Suerte!"
                };
   
                string message = messageArray[characterIndex];
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true);
                PlayAudioText.PlayTextAudio_Static(audioSource, audioClips[characterIndex]);
                ++characterIndex;
            }
        });

        
    }
    private void Start()
    {
        TextWriter.AddWriter_Static(messageText, "En el rec�ndito Hizdharr Village, se alza una mazmorra de la cual ning�n mago ha logrado salir victorioso.", .05f, true, true);
        PlayAudioText.PlayTextAudio_Static(audioSource, audioClips[0]);
    }
}
