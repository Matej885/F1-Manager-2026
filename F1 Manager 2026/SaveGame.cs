using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using F1_Manager_2026;

namespace F1_Manager_2026
{
    public static class SaveGame
    {
        private static string subor = "SaveGameF1MNGR.json";

        /// <summary>
        /// Uloží aktuálnu inštanciu databázy do JSON súboru.
        /// </summary>
        public static void Save(Database database)
        {
            try
            {
                string json = JsonSerializer.Serialize(database, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(subor, json);
            }
            catch (Exception ex)
            {
                // V reálnej aplikácii by tu bolo logovanie
                System.Diagnostics.Debug.WriteLine($"Chyba pri ukladaní: {ex.Message}");
            }
        }

        /// <summary>
        /// Načíta dáta zo súboru a preleje ich priamo do Database.Instance.
        /// </summary>
        public static void Load()
        {
            if (!File.Exists(subor))
            {
                return;
            }

            try
            {
                string json = File.ReadAllText(subor);
                Database loadedDatabase = JsonSerializer.Deserialize<Database>(json);

                if (loadedDatabase != null)
                {
                    // KRITICKÝ KROK: Priradenie načítaných dát do globálneho Singletonu
                    Database.Instance = loadedDatabase;

                    // POISTKA: Kalendár sa zvyčajne do JSONu neukladá celý (alebo môže byť null),
                    // preto ho po načítaní pre istotu znovu inicializujeme.
                    if (Database.Instance.Calendar2026 == null || Database.Instance.Calendar2026.Count == 0)
                    {
                        Database.Instance.FillCalendar();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Chyba pri načítaní: {ex.Message}");
            }
        }

        /// <summary>
        /// Odstráni uloženú hru.
        /// </summary>
        public static void DeleteSave()
        {
            if (File.Exists(subor))
            {
                File.Delete(subor);
            }
        }
    }
}