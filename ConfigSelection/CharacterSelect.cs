using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerConfigSelection
{
    public class CharacterStatus
    {
        public string Name { get; set; }
        public bool Hide { get; set; }
    }

    public class CharacterSelect
    {
        const string SaveGamePath = @"\My Games\Skyrim\Saves\";
        const string HiddenExtension = ".TAZ";
        const string SearchPartOne = "Save ";
        const string SearchPartTwo = " - ";
        const string AllCharacters = "All Characters";
        const string AutoSave = "AUTOSAVE";
        public List<string> DirectoryList
        {
            get { return  Directory.GetFiles(SavePath).ToList<string>(); }          
        }

        public Dictionary<string, CharacterStatus> CharacterDictionary;

        public string SavePath { get; set; }
        public bool NotFoundSaveDir { get; private set; }

        public CharacterSelect()
        {
            //check if entry exists in registry for path
            SavePath = string.Format(@"{0}{1}", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), SaveGamePath);
            NotFoundSaveDir = (!Directory.Exists(SavePath)); //set the flag
        }


        //public List<string> CharacterList() 
        public Dictionary<string, CharacterStatus> CharacterList()
        {
            var fileList = DirectoryList;
            List<string> charReturn = new List<string>();
            CharacterDictionary = new Dictionary<string, CharacterStatus>();
            foreach (var character in fileList)
            {
                string fileName = Path.GetFileName(character);
                string fileExt = Path.GetExtension(character).ToUpper();
                bool validSkyrimFile = fileExt.Contains(".ESS") || fileExt.Contains(".SKSE") || fileExt.Contains(".TAZ");
                if (!fileName.ToUpper().Contains(AutoSave))
                {
                    string[] shortName = fileName.Split(' ');
                    if (shortName.Count() > 3 && validSkyrimFile && !charReturn.Contains(shortName[3], StringComparer.OrdinalIgnoreCase))
                    {
                        charReturn.Add(shortName[3]);
                        CharacterDictionary.Add(shortName[3], new CharacterStatus { Name= shortName[3] , Hide= fileExt.Contains(".TAZ") });
                    }
                }
            }
            charReturn.Sort(); //sort and bale
            charReturn.Insert(0, AllCharacters);
            //return charReturn;
            return CharacterDictionary;
        }

        public bool UpdateFileExtension()
        {
            Utilities.Utilities.log.Info("Entering UpdateFileExtension()");
            bool _return = false;
            var fileList = DirectoryList;
            fileList = fileList.ConvertAll(x => x.ToUpper());//set upper case
            foreach (var item in CharacterDictionary)
            {
                CharacterStatus charStatus = item.Value;
                var charFiles = fileList.Where(p => p.Contains(charStatus.Name.ToUpper())).ToList(); //grab all the files associated with the character
                foreach (var file in charFiles) //update all the files
                {
                    string fileExt = Path.GetExtension(file);
                    bool validFile = fileExt.Contains(".ESS") || fileExt.Contains(".SKSE") || fileExt.Contains(".TAZ");
                    var fileNotUpperCase = DirectoryList.Find(p => p.ToUpper() == file);
                    if (validFile)
                    {
                        if (charStatus.Hide)
                        {
                            if (fileExt.Contains(".ESS") || fileExt.Contains(".SKSE"))
                            {
                                try
                                {
                                    File.Move(fileNotUpperCase, string.Format("{0}{1}", fileNotUpperCase, HiddenExtension));
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                        else
                        {
                            if (fileExt.Contains(".TAZ"))
                            {
                                try
                                {
                                    File.Move(fileNotUpperCase, Path.ChangeExtension(fileNotUpperCase, null));
                                }
                                catch (Exception e)
                                {
                                    Utilities.Utilities.log.Error(Utilities.Utilities.GetExceptionMessage(e));
                                }
                            }
                                
                        }
                    }
                }

            }
            Utilities.Utilities.log.Info("leaving UpdateFileExtension()");
            return _return;
        }
    }
}
