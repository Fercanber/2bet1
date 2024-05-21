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
                 "En el recóndito Hizdharr Village, se alza una mazmorra de la cual ningún mago ha logrado salir victorioso.",
                 "Oculta en sus entrañas se encuentra La Vara de Hizdharr, un objeto de poder inimaginable que concede a su poseedor sabiduría y magia superiores a las de cualquier hechicero.",
                 "Dos magos de renombre, Prometheuss y Roosswall, llegaron al pueblo con la firme intención de conquistar la mazmorra y reclamar la vara.",
                 "Al adentrarse en sus sombrías galerías, los senderos se bifurcan, llevando a Prometheuss y Roosswall por rutas divergentes.\r\n",
                 "Deberás comunicarte con tu compañero para resolver los diferentes problemas, enigmas y acertijos que se interpondrán en vuestro camino.",
                 "Estos enigmas y acertijos, se encontrarán escondidos en cada nivel, por tanto deberás primero encontrarlos para poder resolverlos.",
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
        TextWriter.AddWriter_Static(messageText, "En el recóndito Hizdharr Village, se alza una mazmorra de la cual ningún mago ha logrado salir victorioso.", .05f, true, true);
        PlayAudioText.PlayTextAudio_Static(audioSource, audioClips[0]);
    }
}
