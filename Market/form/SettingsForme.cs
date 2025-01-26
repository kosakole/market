using Market.interfaces;
using Market.Languages;
using Market.Settings;
using Market.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.form
{
    public partial class SettingsForme : Form, ChangeSettings
    {
        public SettingsForme()
        {
            InitializeComponent();
            init();
            initForm();
            
            ChangeSettings = new List<ChangeSettings>();
            chageSettings();
        }

        public SettingsForme(List<ChangeSettings> cs) : this()
        {
            foreach(ChangeSettings cs2 in cs) 
            {
                ChangeSettings.Add(cs2);
            }
        }

        public SettingsForme(ChangeSettings cs) : this()
        {
            ChangeSettings.Add(cs);
        }
        private void init() 
        {
            Language language = Setting.GetSettings().Language;
            string key;
            key = "English";
            ENG = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Serbian";
            SRB = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Dark";
            DARK = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Light";
            LIGHT = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Normal";
            NORMAL = language.Words.ContainsKey(key) ? language.Words[key] : "";

            comboBoxLanguage.Items.Clear();
            comboBoxLanguage.Items.Add(ENG);
            comboBoxLanguage.Items.Add(SRB);

            if(Setting.GetSettings().Language.GetType() == typeof(SerbianLanguage))
                comboBoxLanguage.SelectedItem = SRB;
            else if (Setting.GetSettings().Language.GetType() == typeof(EnglishLanguage))
                comboBoxLanguage.SelectedItem = ENG;

            comboBoxTheme.Items.Clear();
            comboBoxTheme.Items.Add(DARK);
            comboBoxTheme.Items.Add(LIGHT);
            comboBoxTheme.Items.Add(NORMAL);

            if (Setting.GetSettings().Theme.GetType() == typeof(DarkThem))
                comboBoxTheme.SelectedItem = DARK;
            else if (Setting.GetSettings().Theme.GetType() == typeof(LightTheme))
                comboBoxTheme.SelectedItem = LIGHT;
            else if (Setting.GetSettings().Theme.GetType() == typeof(NormalTheme))
                comboBoxTheme.SelectedItem = NORMAL;
        }

        private void initForm()
        { 
            labels.Add(labelLanguage);
            labels.Add(labelTheme);

            comboBoxes.Add(comboBoxLanguage);
            comboBoxes.Add(comboBoxTheme);
        }

        public void chageSettings()
        {
            setLanguage(Setting.GetSettings().Language);
            changeTheme(Setting.GetSettings().Theme);
            if (ChangeSettings != null)
                foreach (ChangeSettings item in ChangeSettings)
                {
                    try
                    {
                        item.chageSettings();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
        }

        private void setLanguage(Language language)
        {
            string key;

            key = "Language";
            labelLanguage.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
            key = "Theme";
            labelTheme.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";

            key = "Settings";
            this.Text = language.Words.ContainsKey(key) ? language.Words[key] : "";
        }

        public void changeTheme(Theme theme)
        {
            foreach (Label l in labels)
            {
                theme.set(l);
            }

            foreach (ComboBox t in comboBoxes)
            {
                theme.set(t);
            }
            theme.set(this);
            return;
        }
        

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLanguage.SelectedItem.ToString() == SRB)
                Setting.GetSettings().Language = new SerbianLanguage();
            else
                Setting.GetSettings().Language = new EnglishLanguage();
            chageSettings();
        }

        private void comboBoxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTheme.SelectedItem.ToString() == LIGHT)
                Setting.GetSettings().Theme = new LightTheme();
            else if (comboBoxTheme.SelectedItem.ToString() == DARK)
                Setting.GetSettings().Theme = new DarkThem();
            else if (comboBoxTheme.SelectedItem.ToString() == NORMAL)
                Setting.GetSettings().Theme = new NormalTheme();
            chageSettings();
        }

        private List<ChangeSettings> ChangeSettings;
        private List<Label> labels = new List<Label>();
        private List<ComboBox> comboBoxes = new List<ComboBox>();
        private static string ENG;
        private static string SRB;
        private static string DARK;
        private static string LIGHT;
        private static string NORMAL;
    }
}
