
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class UIInventoryManager : MonoBehaviour
{
    public GameObject prefabes_object;
    public Transform panel_contain;

    void Start()
    {
        SetUIslote();
    }


    public void SetUIslote()
    {

        Texture2D[] source;
        
        DirectoryInfo dir = new DirectoryInfo("Assets/Iteams");
        FileInfo[] info = dir.GetFiles("*.png");
               
        source = new Texture2D[info.Length];       
        foreach (var fileName in info)
        {

            GameObject obj = Instantiate(prefabes_object);            
            obj.GetComponentInChildren<RawImage>().texture = LoadTextureFromPath(fileName.ToString());
            obj.transform.SetParent(panel_contain);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

        }

    }

    private Texture2D LoadTextureFromPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.LogError("Texture path is null or empty");
            return null;
        }

        if (!File.Exists(path))
        {
            Debug.LogError($"File not found: {path}");
            return null;
        }

        byte[] bytes = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(5, 5, TextureFormat.RGB24, false);
        texture.LoadImage(bytes);
     

        return texture;
    }




}
