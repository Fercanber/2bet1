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
       audioSource = transform.Find("Body").GetComponent<AudioSource>();   
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
                 "Ey despertad!",
                 "Rommy, Fiira!",
                 "Hemos tenido un pequeño accidente con el barco volador estais bien?\r\n",
                 "Estamos bastante cerca de puerto marfil, uhmmmm que tal si usais vuestra magia para recoger el equipaje y comemos rico en la posada antes de seguir nuestro camino.\r\n",
                 "Recordad que vuestra magia funciona mejor si lo haceis a la vez"
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
        TextWriter.AddWriter_Static(messageText, "Ey despertad!", .05f, true, true);
        PlayAudioText.PlayTextAudio_Static(audioSource, audioClips[0]);
    }
}
