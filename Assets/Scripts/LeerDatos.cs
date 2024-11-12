using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Numerics;
using UnityEngine.Networking.PlayerConnection;

[System.Serializable]
public class Message
{
    public string id;
    //public string text;
    //public string text2;
    public string[] texts;
}

[System.Serializable]
public class MessageData
{
    public List<Message> messages;
}

public class LeerDatos : MonoBehaviour
{
    private MessageData messageData;

    private void Awake()
    {
        // Cargar el archivo JSON desde Resources
        TextAsset jsonTextFile = Resources.Load<TextAsset>("textData");

        if (jsonTextFile != null)
        {
            // Deserializar el JSON en un objeto MessageData
            messageData = JsonUtility.FromJson<MessageData>(jsonTextFile.text);
           // string[] aux = MostrarMensajes("Entrevistador");
        }
        else
        {
            Debug.Log("El archivo JSON no existe en Resources.");
        }
    }

    // Método para mostrar los mensajes en la consola
    private string[] MostrarMensajes(string id)
    {
        string[] aux = null;
        if (messageData != null && messageData.messages != null)
        {
            foreach (Message message in messageData.messages)
            {
                if(message.id == id)
                {
                    return message.texts;
                }
            }
        }
        else
        {
            Debug.Log("No hay mensajes para mostrar.");
        }
        return null;

    }


}
