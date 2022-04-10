namespace Core;

public interface IPatternFinder
{
    public IReadOnlyCollection<PatternEntrance> Find(string folderPath, string pattern);
}