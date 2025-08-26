using ObjectTK.Net.Shaders;
using ObjectTK.Net.Shaders.Sources;
using ObjectTK.Net.Shaders.Variables;
using ObjectTK.Net.Textures;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

namespace ObjectTK.Net.Examples.Shaders
{
    [VertexShaderSource("Skybox.Vertex")]
    [FragmentShaderSource("Skybox.Fragment")]
    public class SkyboxProgram
        : Program
    {
        [VertexAttrib(3, VertexAttribPointerType.Float)]
        public VertexAttrib InPosition { get; protected set; }

        public Uniform<Matrix4> ModelViewProjectionMatrix { get; protected set; }
        public TextureUniform<TextureCubemap> Texture { get; protected set; }
    }
}