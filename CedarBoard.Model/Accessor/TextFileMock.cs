namespace CedarBoard.Model.Accessor
{
    public class TextFileMock : ITextFile
    {
        public string? Value { get; set; }

        public string? GetData(string file) => Value;

        public void SetData(string file, string value) => Value = value;

    }
}
