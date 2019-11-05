# Unity3D With Azure Blob Storage
 This is a Unity demonstration that utilizes Azure Blob Storage to read/write to a log file. Client example usage for AR Sphere.
 
# How it works

To use `WindowsAzure.Storage`, download the `.unitypackage` using NuGet2Unity, or from [here](https://github.com/BrianPeek/AzureSDKs-Unity/tree/master/_UnityPackages). 

The cube rendered on the screen runs the script `Program.cs`. 

The connection string can typically be found on your Azure Portal. Input your connection string into the InputField, and hit Return. This calls a method that connects to the Blob storage using the connection string.

In the sample code, a container called `example` is created, where `log.txt` is read and updated to append the current date/time. Pretty cool!

Open up Microsoft Azure Storage Explorer to see the result below.

![](blob.PNG)
