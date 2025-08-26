﻿using ObjectTK.Net.Shaders;
using ObjectTK.Net.Shaders.Sources;
using ObjectTK.Net.Shaders.Variables;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;

namespace ObjectTK.Net.Examples.Shaders
{
    [VertexShaderSource("SimpleColor.Vertex")]
    [FragmentShaderSource("SimpleColor.Fragment")]
    public class SimpleColorProgram
        : Program
    {
        [VertexAttrib(3, VertexAttribPointerType.Float)]
        public VertexAttrib InPosition { get; protected set; }
        [VertexAttrib(4, VertexAttribPointerType.UnsignedByte, true)]
        public VertexAttrib InColor { get; protected set; }

        public Uniform<Matrix4> ModelViewProjectionMatrix { get; protected set; }
    }
}