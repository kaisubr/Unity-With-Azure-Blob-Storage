using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

public class Program : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script runs when cube is rendered.");
        GameObject ifieldobj = GameObject.Find("Canvas/param");
        InputField ifield = ifieldobj.GetComponent<InputField>();
        ifield.onEndEdit.AddListener(ParameterInput);

    }

    //User enters connection string and hits Return key.
    public void ParameterInput(string cxnstr)
    {
        Debug.Log(cxnstr);

        CloudStorageAccount act = CloudStorageAccount.Parse(cxnstr);
        CloudBlobClient client = act.CreateCloudBlobClient();

        var container = client.GetContainerReference("example");
        container.CreateIfNotExistsAsync().Wait();

        CloudBlockBlob blob = container.GetBlockBlobReference("log.txt");
        //blob.UploadTextAsync("Unity upload").Wait();
        appendText(blob, "Unity log: " + System.DateTime.UtcNow.ToString("MM-dd-yyyy hh:mm:ss"));
    }

    public static async Task appendText(CloudBlockBlob blob, string v)
    {
        var upload = v;

        if (await blob.ExistsAsync())
        {
            //append. here we test retrieval & read...
            var content = await blob.DownloadTextAsync();

            upload = content + "\n" + v;
        }

        blob.UploadTextAsync(upload).Wait();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
