namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor= new GraphicEditor();
            Triangle triangle= new Triangle();
            graphicEditor.DrawShape(triangle);
        }
    }
}
