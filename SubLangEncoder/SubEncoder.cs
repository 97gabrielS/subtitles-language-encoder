using System.IO;

// ReSharper disable StringIndexOfIsCultureSpecific.1

namespace SubLangEncoder
{
    public class SubEncoder
    {
        private readonly string _path;
        private readonly string _langCode;

        public SubEncoder(string path, string langCode)
        {
            _path = path;
            _langCode = langCode;
        }

        public void Encode()
        {
            var rootDirectory = new DirectoryInfo(_path);
            var subtitleFiles = rootDirectory.EnumerateFiles("*.srt", SearchOption.AllDirectories);
            foreach (var subFile in subtitleFiles)
            {
                var subFileName = subFile.Name;
                if (!subFileName.Contains(_langCode))
                {
                    var newSubPath = GetNewSubPathWithLangCodeInserted(subFile.DirectoryName, subFile.Name);
                    subFile.MoveTo(newSubPath);
                }
            }
        }

        private string GetNewSubPathWithLangCodeInserted(string subDirectoryPath, string subName)
        {
            var startIdx = subName.IndexOf(".srt");
            var newSubFileName =
                subName.Insert(startIdx, _langCode); // inserts the language code into the subtitle file's name
            return $"{subDirectoryPath}\\{newSubFileName}";
        }
    }
}