using Cookbook.FileAccess;

namespace Cookbook;

public static class FileFormatExtensions
{
    public static string AsFileExtension(this FileFormat fileFormat) => fileFormat == FileFormat.JSON ? "json" : "txt";
}