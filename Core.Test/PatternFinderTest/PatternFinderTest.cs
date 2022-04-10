using System.IO;
using NUnit.Framework;

namespace Core.Test.PatternFinderTest;

internal sealed class PatternFinderTest
{
    private PatternFinder patternFinder = default!;

    [SetUp]
    public void TestInitialize()
    {
        patternFinder = new PatternFinder();
    }

    [Test]
    public void NonExistingFolder()
    {
        var folderPath = BuildAbsolutePath("nonExisting");
        var exception = Assert.Throws<FolderNotFoundException>(() => patternFinder.Find(folderPath, "anything"));
        Assert.AreEqual(exception, $"Can not find a folder with path {folderPath}");
    }

    [Test]
    public void SingleFileWithPattern()
    {
        var folderPath = BuildAbsolutePath("PatternFinderTest\\Resources\\SingleFileWithPattern");
        var expected = new[] { new PatternEntrance("1.txt") };
        var actual = patternFinder.Find(folderPath, "word2");

        CollectionAssert.AreEqual(expected, actual);
    }

    private string BuildAbsolutePath(string relativeToRootPath) => Path.Combine(Directory.GetCurrentDirectory(), relativeToRootPath);
}