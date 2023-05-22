namespace GenericBoxOfString
{
    public class Box<T>
    {
        private readonly string _text;

        public Box(string text)
        {
            this._text = text;
        }

        public override string ToString()
        {
            return $"{this._text.GetType()}: {this._text}";
        }
    }
}