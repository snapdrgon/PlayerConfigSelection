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
            try
            {
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
            }
            catch (Exception e)
            {
                Utilities.Utilities.log.Error(Utilities.Utilities.GetExceptionMessage(e));
            }
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
                                    var fileNameOriginal = fileNotUpperCase;
                                    var fileNameNew = $"{fileNotUpperCase}{HiddenExtension}";
                                    if (!FileEquals(fileNameOriginal, fileNameNew))
                                    {
                                        File.Move(fileNameOriginal, fileNameNew);
                                        Utilities.Utilities.log.Info($"Renamed {fileNameOriginal} to {fileNameNew}");
                                    }
                                    else
                                    {
                                        File.Delete(fileNameOriginal);
                                        Utilities.Utilities.log.Info($"Deleted {fileNameOriginal}");

                                    }
                                }
                                catch (Exception e)
                                {
                                    Utilities.Utilities.log.Error(Utilities.Utilities.GetExceptionMessage(e));
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

        bool FileEquals(string path1, string path2)
        {
            bool returnFlag = false;
            try
            {
               byte[] file1 = File.ReadAllBytes(path1);
                byte[] file2 = File.ReadAllBytes(path2);
                if (file1.Length == file2.Length)
                {
                    for (int i = 0; i < file1.Length; i++)
                    {
                        if (file1[i] != file2[i])
                        {
                            returnFlag = false;
                        }
                    }
                    returnFlag = true;
                }
                else
                {
                    returnFlag = false;
                }
            }
            catch (Exception)
            {
                returnFlag = false;
            }
            return returnFlag;
         }
    }
}
