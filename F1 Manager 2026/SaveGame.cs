using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using F1_Manager_2026;

public static class SaveGame
    {
        private static string subor = "SaveGameF1MNGR.json";

        public static void Save(Database database)
        {
            // Serializuje objekt Player do JSON formátu a uloží ho do súboru
            string json = JsonSerializer.Serialize(database, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(subor, json);
        }

        public static Database Load()
        {
            // Načíta uloženú hru zo súboru, ak existuje, inak vráti null
            if (!File.Exists(subor))
            {
                return null;
            }

            string json = File.ReadAllText(subor);
            return JsonSerializer.Deserialize<Database>(json);
        }
        public static void DeleteSave()
        {
            // Odstráni súbor so save hrou, ak existuje
            if (File.Exists(subor))
            {
                File.Delete(subor);
            }
        }
    }

namespace F1_Manager_2026
{
    public static class SaveGame
    {
        private static string subor = "save.json";

        public static void Save(Database database)
        {
            // Serializuje objekt Player do JSON formátu a uloží ho do súboru
            string json = JsonSerializer.Serialize(database, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(subor, json);
        }

        public static Database Load()
        {
            // Načíta uloženú hru zo súboru, ak existuje, inak vráti null
            if (!File.Exists(subor))
            {
                return null;
            }

            string json = File.ReadAllText(subor);
            return JsonSerializer.Deserialize<Database>(json);
        }
        public static void DeleteSave()
        {
            // Odstráni súbor so save hrou, ak existuje
            if (File.Exists(subor))
            {
                File.Delete(subor);
            }
        }
    }

}
