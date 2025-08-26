//
// FreeLookBehavior.cs
//
// Copyright (C) 2018 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

using OpenTK.Input;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

using Keys = OpenTK.Windowing.GraphicsLibraryFramework.Keys;


namespace ObjectTK.Tools.Cameras
{
    public class FreeLookBehavior
        : CameraBehavior
    {
        public FreeLookBehavior(MouseState mouseState, KeyboardState keyboardState) : base(mouseState, keyboardState)
        {

        }

        public override void UpdateFrame(CameraState state, float step)
        {
            var dir = Vector3.Zero;
            var leftRight = Vector3.Cross(state.Up, state.LookAt).Normalized();
            if (KeyboardState.IsKeyDown(Keys.W)) dir += state.LookAt;
            if (KeyboardState.IsKeyDown(Keys.S)) dir -= state.LookAt;
            if (KeyboardState.IsKeyDown(Keys.A)) dir += leftRight;
            if (KeyboardState.IsKeyDown(Keys.D)) dir -= leftRight;
            if (KeyboardState.IsKeyDown(Keys.Space)) dir += state.Up;
            if (KeyboardState.IsKeyDown(Keys.LeftControl)) dir -= state.Up;
            // normalize dir to enforce consistent movement speed, independent of the number of keys pressed
            if (dir.LengthSquared > 0) state.Position += dir.Normalized() * step;
        }

        public override void MouseMove(CameraState state, Vector2 delta)
        {   
            if (MouseState.IsButtonDown(MouseButton.Left))
            {
                HandleFreeLook(state, delta);
            }
        }
    }
}