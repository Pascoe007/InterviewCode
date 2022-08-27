
using InterviewCodeProject;

var versionNumberChange = new VersionNumberChange();
Console.WriteLine("Please paste file location");
string filepath = versionNumberChange.GetFilePath(Console.ReadLine());
Console.WriteLine("Currnet Version: " + versionNumberChange.FindVersionNumber(versionNumberChange.GetFileData(filepath)));
Console.WriteLine("Is this Update a Feature Or a Bug Fix?\n" +
    "1: Feature\n" +
    "2: Bug Fix");
int? userInput = versionNumberChange.convertUserInputToInt(Console.ReadLine());
while (userInput == null || !versionNumberChange.BetweenRanges(1, 2, userInput))
{
    userInput = versionNumberChange.convertUserInputToInt(Console.ReadLine());
}
switch (userInput)
{
    case 1:
        Console.WriteLine("Increasing Minjor Number & Reseting Minor Number");
        versionNumberChange.FeatureUpdate(
            versionNumberChange.GetFileData(filepath),
            versionNumberChange.FindVersionNumber(versionNumberChange.GetFileData(filepath)),
            filepath);
        break;
    case 2:
        Console.WriteLine("Increasing Mionor Number");
        versionNumberChange.BugFixUpdate(
            versionNumberChange.GetFileData(filepath),
            versionNumberChange.FindVersionNumber(versionNumberChange.GetFileData(filepath)),
            filepath);
        break;
    default:
        break;
}
Console.WriteLine("New Version: " + versionNumberChange.FindVersionNumber(versionNumberChange.GetFileData(filepath)));