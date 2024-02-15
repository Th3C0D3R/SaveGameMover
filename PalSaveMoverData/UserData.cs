using Newtonsoft.Json;
using SaveGameMoverData.Properties;
using System;
using System.ComponentModel;
using System.Reflection;

namespace SaveGameMoverData
{
    public static class UserData
    {
        private static BindingList<Profile> _profiles = new BindingList<Profile>();
        public static bool IsSaveMode
        {
            get => GetSetting<bool>("IsBackupMode");
            set => SetSetting("IsBackupMode", value);
        }
        public static Guid LastUsedProfile
        {
            get => GetSetting<Guid>("LastUsedProfile");
            set => SetSetting("LastUsedProfile", value);
        }
        public static BindingList<Profile> Profiles
        {
            get => _profiles;
            set => _profiles = value;
        }
        public static bool cbCreateBackup
        {
            get => GetSetting<bool>("CreateBackupCB");
            set => SetSetting("CreateBackupCB", value);
        }
        public static bool cbGenerateLog
        {
            get => GetSetting<bool>("GenerateLogCB");
            set => SetSetting("GenerateLogCB", value);
        }
        public static bool cbDeleteDest
        {
            get => GetSetting<bool>("DeleteCBOverwrite");
            set => SetSetting("DeleteCBOverwrite", value);
        }

        public static bool SaveProfiles()
        {
            return SetSetting("Profiles", JsonConvert.SerializeObject(Profiles));
        }
        public static void LoadProfiles()
        {
            Profiles = JsonConvert.DeserializeObject<BindingList<Profile>>(GetSetting<string>("Profiles"));
            Settings.Default.Upgrade();
        }

        public static void SetProperty<T>(string name, T value)
        {
            PropertyInfo propInf = typeof(UserData).GetProperty(name);
            if (propInf != null)
            {
                propInf.SetValue(null, value);
            }
        }
        public static T GetProperty<T>(string name)
        {
            PropertyInfo propInf = typeof(UserData).GetProperty(name);
            if (propInf != null)
            {
                return (T)propInf.GetValue(null);
            }
            return default;
        }

        internal static bool SetSetting<T>(string Key, T Value)
        {
            bool result;
            try
            {
                Settings.Default[Key] = Value;
                Settings.Default.Save();

                result = true;
            }
            finally
            { }
            return result;
        }
        internal static T GetSetting<T>(string Key)
        {
            T result = (T)Settings.Default[Key];
            return result;
        }
    }
}
