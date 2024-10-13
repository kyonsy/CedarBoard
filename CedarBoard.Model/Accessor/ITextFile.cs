namespace CedarBoard.Model.Accessor
{
    public interface ITextFile
    {
        public string GetData(string file);
        public void SetData(string file, string value);
    }
}
