using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    
    public static void SaveData(UserProfileData profile)
    {
        //Create formatter
        BinaryFormatter formatter = new BinaryFormatter();

        //Create path an open file stream
        string path = Application.persistentDataPath + "/profile.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        //Convert class to binary and save
        formatter.Serialize(stream, profile);
        stream.Close();
    }

    public static UserProfileData LoadData()
    {
        //If file exists at this path
        string path = Application.persistentDataPath + "/profile.save";
        if(File.Exists(path))
        {
            //Create Binary Formatter
            BinaryFormatter formatter = new BinaryFormatter();

            //Open the file from the file stream
            FileStream stream = new FileStream(path, FileMode.Open);

            //Deserialize the file and cast to the designated type ("as UserProfileData" does the casting)
            UserProfileData profile = formatter.Deserialize(stream) as UserProfileData;
            stream.Close();

            return profile;
        }
        else
        {
            Debug.LogError("Save file not found at " + path);
            return null;
        }
    }
}
