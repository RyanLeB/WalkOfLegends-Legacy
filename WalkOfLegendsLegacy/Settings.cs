using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Reflection;


namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Settings
    {

        //---------------
        //Camera Settings
        //---------------
        public static int cameraWidth = 40;
        public static int cameraHeight = 15;
        //---------------
        //Player Settings
        //---------------
        public static char playerChar = 'P';
        public static int playerHealth = 500;
        public static int playerAttack = 100;
        public static int playerStartPosX = 4;
        public static int playerStartPosY = 20;
        //-------------
        //Item Settings
        //-------------
        //Shop settings
        public static int shopDamageCost = 50;
        public static int shopHealthCost = 25;
        public static int freezeCost = 30;
        public static int shopDamageValue = 50;
        public static int shopHealthValue = 30;
        //Health Potion Settings
        public static char healthPotionChar = '@';
        public static string healthPotionName = "Health Potion";
        public static int healthPotionHealAmount = 30;
        //Invincibility Settings
        public static char invincibilityChar = '!';
        public static string invincibilityName = "Invincibility";
        public static int invincibilityEffectTime = 4000;
        //Freeze Settings
        public static char freezeChar = '*';
        public static string freezeName = "Freeze";
        public static int freezeEffectTime = 4000;
        //--------------
        //Enemy Settings
        //--------------
        //Dragon Settings
        public static char dragonChar = 'D';
        public static string dragonName = "Dragon";
        public static int dragonHealth = 10000;
        public static int dragonDamage = 100;
        //Goblin Settings
        public static char goblinChar = 'G';
        public static string goblinName = "Goblin";
        public static int goblinHealth = 150;
        public static int goblinDamage = 20;
        public static int goblinSouls = 25;
        public static string goblinDir = "down";
        //Orc Settings
        public static char orcChar = 'O';
        public static string orcName = "Orc";
        public static int orcHealth = 200;
        public static int orcDamage = 40;
        public static int orcSouls = 50;
        //Minotaur Settings
        public static char minotaurChar = '}';
        public static string minotaurName = "Minotaur";
        public static int minotaurHealth = 400;
        public static int minotaurDamage = 50;
        public static int minotaurSouls = 75;


        // ---- Saves the settings to the file ----

        public static void SaveSettings(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var settings = new Dictionary<string, object>();

            foreach (var field in typeof(Settings).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                settings[field.Name] = field.GetValue(null);
            }

            var json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(filePath, json);
        }

        // ---- Loads the settings from the file ----
        public static void LoadSettings(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var settings = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

                foreach (var setting in settings)
                {
                    var field = typeof(Settings).GetField(setting.Key, BindingFlags.Public | BindingFlags.Static);
                    if (field != null)
                    {
                        object value = null;

                        // Handle specific types
                        if (field.FieldType == typeof(char))
                        {
                            value = setting.Value.GetString()[0];
                        }
                        else if (field.FieldType == typeof(int))
                        {
                            value = setting.Value.GetInt32();
                        }
                        else if (field.FieldType == typeof(string))
                        {
                            value = setting.Value.GetString();
                        }
                        // Add more type checks as needed

                        field.SetValue(null, value);
                    }
                }
            }
            else
            {
                // Create the file with default settings
                SaveSettings(filePath);
            }
        }
    }


}