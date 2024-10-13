namespace CedarBoard.Model.Accessor
{
    public class TextFileAccessor : ITextFile
    {
        public string GetData(string file)
        {
            return File.ReadAllText(file);
        }

        public void SetData(string file, string value)
        {
            File.WriteAllText(file, value);
        }
    }
}
