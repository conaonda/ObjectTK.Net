using System;
using System.Runtime;

using ObjectTK;
using ObjectTK.Shaders;
using ObjectTK.Tools;
using ObjectTK.Tools.Cameras;

using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

using Keys = OpenTK.Windowing.GraphicsLibraryFramework.Keys;

namespace Examples
{
    /// <summary>
    /// Provides common functionality for the examples.
    /// </summary>
    public class ExampleWindow
        : DerpWindow
    {
        protected Camera Camera;
        protected Matrix4 ModelView;
        protected Matrix4 Projection;
        protected string? OriginalTitle { get; private set; }

        public ExampleWindow()
            : base(
                  new GameWindowSettings()
                  {
                      //UpdateFrequency = 250,
                      //UpdateFrequency = 250,
                  },
                  new NativeWindowSettings()
                  {
                      API = ContextAPI.OpenGL,
                      APIVersion = new Version(3, 3),
                      Profile = ContextProfile.Core,
                      AutoLoadBindings = true,
                      Flags = ContextFlags.Debug | ContextFlags.ForwardCompatible,
                      IsEventDriven = false,
                      ClientSize = (800, 600),
                      StartFocused = true,
                      StartVisible = true,
                      WindowBorder = WindowBorder.Resizable,
                      WindowState = WindowState.Normal,
                    })
        {
            // disable vsync
            VSync = VSyncMode.Off;
            // set up camera
            Camera = new Camera();
            Camera.SetBehavior(new ThirdPersonBehavior(MouseState, KeyboardState));
            Camera.DefaultState.Position.Z = 5;
            Camera.ResetToDefault();
            Camera.Enable(this);
            ResetMatrices();
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            
            // remember original title
            OriginalTitle = Title;
            // set search path for shader files and extension
            ProgramFactory.BasePath = "Data/Shaders/";
            ProgramFactory.Extension = "glsl";
        }

        protected override void OnUnload()
        {
            base.OnUnload();
            
            // release all gl resources on unload
            GLResource.DisposeAll(this);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            Title = string.Format("ObjectTK example: {0} - FPS {1}", OriginalTitle, FrameTimer.FpsBasedOnFramesRendered);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);

            // close window on escape press
            if (e.Key == Keys.Escape) Close();
            // reset camera to default position and orientation on R press
            if (e.Key == Keys.R) Camera.ResetToDefault();
        }

        /// <summary>
        /// Resets the ModelView and Projection matrices to the identity.
        /// </summary>
        protected void ResetMatrices()
        {
            ModelView = Matrix4.Identity;
            Projection = Matrix4.Identity;
        }

        /// <summary>
        /// Sets a perspective projection matrix and applies the camera transformation on the modelview matrix.
        /// </summary>
        protected void SetupPerspective()
        {
            // setup perspective projection
            var aspectRatio = this.ClientSize.X / (float)this.ClientSize.Y;
            Projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 0.1f, 1000);
            ModelView = Matrix4.Identity;
            // apply camera transform
            ModelView = Camera.GetCameraTransform();
        }
    }
}