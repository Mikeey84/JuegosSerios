using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Message
{
    public string id;
    public string text;
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
            MostrarMensajes();
        }
        else
        {
            Debug.Log("El archivo JSON no existe en Resources.");
        }
    }

    // M�todo para mostrar los mensajes en la consola
    private void MostrarMensajes()
    {
        if (messageData != null && messageData.messages != null)
        {
            foreach (Message message in messageData.messages)
            {
                Debug.Log($"ID: {message.id} - Texto: {message.text}");
            }
        }
        else
        {
            Debug.Log("No hay mensajes para mostrar.");
        }
    }
}