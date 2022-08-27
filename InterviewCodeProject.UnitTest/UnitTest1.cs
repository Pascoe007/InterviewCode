namespace InterviewCodeProject.UnitTest
{
    public class VersionNumberChangeTest
    {
        private VersionNumberChange _versionNumberChange { get; set; } = null;
        private string _filePath { get; set; } = null;
        [SetUp]
        public void Setup()
        {
            _versionNumberChange = new VersionNumberChange();
            _filePath = @"Z:\C# Code\InterviewCode\InterviewCode\TestFile.txt";
        }

        [Test]
        public void BetweenRanges_CorrectTest()
        {
            var number = 2;
            var result = _versionNumberChange.BetweenRanges(1, 2, number);
            Assert.IsTrue(result);
        }
        [Test]
        public void BetweenRanges_FalseTest()
        {
            var number = 4;
            Assert.Throws<ArgumentOutOfRangeException>(() => _versionNumberChange.BetweenRanges(1, 2, number));
        }
        [Test]
        public void Convert_String_to_Int_Correct()
        {
            var input = "3";
            var result = _versionNumberChange.convertUserInputToInt(input);
            Assert.AreEqual(result, 3);
        }
        [Test]
        public void Convert_String_to_Int_Incorrect()
        {
            var input = "H";
            var result = _versionNumberChange.convertUserInputToInt(input);
            Assert.IsNull(result);
        }
        [Test]
        public void GetFileData_Test_Correct()
        {
            var input = _filePath;
            var result = _versionNumberChange.GetFileData(input);
            Assert.AreEqual(result, File.ReadAllText(input));
        }
        [Test]
        public void GetFilePath_Test_Correct()
        {
            var input = _filePath;
            var result = _versionNumberChange.GetFilePath(input);
            Assert.AreEqual(result, input);
        }
        [Test]
        public void GetVersionNumber_Test_Correct()
        {
            var input = "[assembly: AssemblyVersion('1.1.0.0')]";
            var result = _versionNumberChange.FindVersionNumber(input);
            Assert.AreEqual(result, "1.1.0.0");
        }
        [Test]
        public void GetVersionNumber_Test_Incorrect()
        {
            var input = "";
            var result = _versionNumberChange.FindVersionNumber(input);
            Assert.IsNull(result);
        }
        [Test]
        public void FeatureUpdate_Test_VersionNumber()
        {
            var input = File.ReadAllText(_filePath);
            var input2 = _versionNumberChange.FindVersionNumber(input);
            Version version = new Version(input2);
            var input3 = _filePath;
            var result = _versionNumberChange.FeatureUpdate(input, input2, input3);
            Assert.AreEqual(result, $"{version.Build}.{version.Revision}.{version.Major + 1}.0");
        }
        [Test]
        public void BugFix_Test_VersionNumber()
        {
            var input = File.ReadAllText(_filePath);
            var input2 = _versionNumberChange.FindVersionNumber(input);
            Version version = new Version(input2);
            var input3 = _filePath;
            var result = _versionNumberChange.BugFixUpdate(input, input2, input3);
            Assert.AreEqual(result, $"{version.Build}.{version.Revision}.{version.Major}.{version.Minor + 1}");
        }
    }
}