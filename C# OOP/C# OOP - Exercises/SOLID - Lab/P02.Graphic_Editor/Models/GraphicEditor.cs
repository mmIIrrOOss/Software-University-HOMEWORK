namespace P02.Graphic_Editor.Models
{
    using Contracts;

    public class GraphicEditor
    {
        public string Draw(IShape shape)
        {
            return shape.Draw();
        }
    }
}
