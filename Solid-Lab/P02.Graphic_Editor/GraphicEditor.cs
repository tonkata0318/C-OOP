using System;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        
        public void DrawShape(IShape shape)
        {
            Type type= shape.GetType();
            if (shape==shape as object)
            {
                Console.WriteLine($"I'm {type.Name}");
            }
            //else if (shape==shape as Rectangle)
            //{
            //    Console.WriteLine("I'm Recangle");
            //}
            //else if (shape==shape as Square)
            //{
            //    Console.WriteLine("I'm Square");
            //}
            
        }
    }
}
