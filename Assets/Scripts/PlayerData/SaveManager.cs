using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager 
{
    private static string settingsPath = Application.persistentDataPath + "/settings.fp";
    private static BinaryFormatter formatter = new BinaryFormatter();
    private static Stream stream;

    public static void SaveSettings(SettingsData data)
    {
        try
        {
            stream = new FileStream(settingsPath, FileMode.Create);
            formatter.Serialize(stream, data);
            
        }
        catch (System.Exception)
        {

            throw;
        }
        finally
        {
            stream.Close();
        }
        Debug.Log("saved to: " + settingsPath);
    }

    public static SettingsData LoadSettings()
    {
        if (File.Exists(settingsPath))
        {
            stream = new FileStream(settingsPath, FileMode.Open);
            SettingsData data = formatter.Deserialize(stream) as SettingsData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}
