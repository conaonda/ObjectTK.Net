using ObjectTK.Net.Shaders;
using ObjectTK.Net.Shaders.Sources;
using ObjectTK.Net.Shaders.Variables;
using ObjectTK.Net.Textures;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

namespace ObjectTK.Net.Examples.Shaders
{
    [VertexShaderSource("TextureGrid.Vertex")]
    [GeometryShaderSource("TextureGrid.Geometry")]
    [FragmentShaderSource("TextureGrid.Fragment")]
    public class TextureGridProgram
        : Program
    {
        [VertexAttrib(2, VertexAttribPointerType.Float)]
        public VertexAttrib InPosition { get; protected set; }
        [VertexAttrib(1, VertexAttribPointerType.Float)]
        public VertexAttrib InTexture { get; protected set; }

        public Uniform<Matrix4> ModelViewProjectionMatrix { get; protected set; }
        public TextureUniform<Texture2DArray> TextureData { get; protected set; }
    }
}