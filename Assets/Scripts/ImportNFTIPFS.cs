using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;

public class ImportNFTIPFS : MonoBehaviour
{
    //int _rotationSpeed = 6;
    public string contract;
    public GameObject inputField;

    [Serializable]
    public class Attribute
    {
        public string trait_type { get; set; }
        public string value { get; set; }
    }
    [Serializable]
    public class Response
    {
        public string image { get; set; }
        public List<Attribute> attributes { get; set; }
    }

    public GameObject[] gameObject;
    public async void GetImage()
    {
        contract = inputField.GetComponent<Text>().text;
        string chain = "ethereum";
        string network = "mainnet";
        // BAYC contract address
       
        string tokenId = "6416";

        // fetch uri from chain
        string uri = await ERC721.URI(chain, network, contract, tokenId);
        print("uri: " + uri);

        if (uri.StartsWith("ipfs://"))
        {
            uri = uri.Replace("ipfs://", "https://ipfs.io/ipfs/");
        }
        print("URI: " + uri);
        // fetch json from uri

        UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        await webRequest.SendWebRequest();
        Response data = JsonConvert.DeserializeObject<Response>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
        print("Data: " + data.image);

        // parse json to get image uri
        string imageUri = data.image;
        if (imageUri.StartsWith("ipfs://"))
        {
            imageUri = imageUri.Replace("ipfs://", "https://ipfs.io/ipfs/");
        }
        print("imageUri: " + imageUri);
        print("Attibutes: " + data.attributes[0].trait_type);
        print("Attibutes: " + data.attributes[1].trait_type);
        print("Attibutes: " + data.attributes[2].trait_type);


        // fetch image and display in game
        UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(imageUri);
        await textureRequest.SendWebRequest();
       for(int i = 0; i < gameObject.Length; i++){
        this.gameObject[i].GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;
       }
    }

   /* public void FixedUpdate()
    {
        // be sure to capitalize Rotate or you'll get errors
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, -2);
    }*/
}
