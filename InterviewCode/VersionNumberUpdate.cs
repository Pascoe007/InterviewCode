
using System.Text.RegularExpressions;

namespace InterviewCodeProject
{
    public class VersionNumberChange
    {
        public int? convertUserInputToInt(string? _userInput)
        {
            try
            {
                return int.Parse(_userInput);
            }
            catch (Exception)
            {
                Console.WriteLine($"Cannot use {_userInput.GetType()}. Please use a number");
                return null;
            }
        }
        public bool BetweenRanges(int a, int b, int? number)
        {
            // a= 1
            // b = 2
            //number = 3
            if (a > number || number > b)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }
            return true;
        }
        public string GetFilePath(string? _filepath)
        {
            while (!File.Exists(_filepath))
            {
                Console.WriteLine("File does not exist");
                _filepath = Console.ReadLine();
            }
            return _filepath;
        }
        public string GetFileData(string _filePath)
        {
            return File.ReadAllText(_filePath);
        }
        public string FindVersionNumber(string _fileData)
        {
            //[assembly:AssemblyVersion("1.1.0.0")]
            Regex regex = new Regex(@"(\d+\.\d+\.\d+\.\d+)");
            if (regex.IsMatch(_fileData))
            {
                var regexText = regex.Match(_fileData).Groups[1].Value;
                return regexText;
            }
            return null;

        }
        public string FeatureUpdate(string _fileData, string _versionNumber, string _filepath)
        {
            Version version = new Version(_versionNumber);
            int major = version.Major;
            string text = _fileData.Replace(_versionNumber, $"{major + 1}.0.{version.Build}.{version.Revision}");
            File.WriteAllText(_filepath, text);
            return $"{version.Build}.{version.Revision}.{major + 1}.0";
        }
        public string BugFixUpdate(string _fileData, string _versionNumber, string _filepath)
        {
            Version version = new Version(_versionNumber);
            string text = _fileData.Replace(_versionNumber, $"{version.Major}.{version.Minor + 1}.{version.Build}.{version.Revision}");
            File.WriteAllText(_filepath, text);
            return $"{version.Build.ToString()}.{version.Revision}.{version.Major}.{version.Minor + 1}";
        }
    }
}