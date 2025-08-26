//
// ThirdPersonBehavior.cs
//
// Copyright (C) 2018 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

using OpenTK.Input;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ObjectTK.Net.Tools.Cameras
{
    public class ThirdPersonBehavior
        : CameraBehavior
    {
        public ThirdPersonBehavior(MouseState mouseState, KeyboardState keyboardState) : base(mouseState, keyboardState) { }

        public Vector3 Origin;

        protected void UpdateDistance(CameraState state, float scale)
        {
            state.Position = Origin - (state.Position - Origin).Length * (1 + scale) * state.LookAt;
        }

        public override void Initialize(CameraState state)
        {
            // recalculate look at direction
            state.LookAt = Origin - state.Position;
            state.LookAt.Normalize();
        }

        public override void MouseMove(CameraState state, Vector2 delta)
        {   
            if (MouseState.IsButtonDown(MouseButton.Left))
            {
                // rotate look direction with mouse
                HandleFreeLook(state, delta);
                // recalculate the position
                UpdateDistance(state, 0);
            }
            if (MouseState.IsButtonDown(MouseButton.Right))
            {
                UpdateDistance(state, delta.Y);
            }
        }

        public override void MouseWheelChanged(CameraState state, float delta)
        {
            if (delta > 100) delta = 100;
            UpdateDistance(state, -delta);
        }
    }
}