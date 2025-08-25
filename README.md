What is ObjectTK.Net?
======

ObjectTK.Net is a .Net version of ObjectTK developed based on .NetFramework.
Unfortunately, ObjectTK development will (probably) cease in 2022, so I had to fork it to use ObjectTK on a modern .Net basis.

What is ObjectTK?
======

ObjectTK is a thin abstraction layer on top of OpenTK to provide OpenGL features in an object-oriented and mostly type-safe manner with modern C#-style.
It is fully aimed at modern OpenGL and compatible to the OpenGL4 core profile.

Currently there are types for the following OpenGL features:
* Programs and Shaders
* Textures
* Vertex array objects
* Buffer objects
* Sampler objects
* Query objects
* Framebuffers
* Renderbuffers

The main advantages of using these types are:
* Cleaner interface than using the OpenGL API directly.
* Type-safety when suitable.
* Removes the necessary but error-prone boilerplate code from your project.
* Immediate detection of leaked resources.
* Information log via log4net.
* The Debug-Build also includes additional sanity-checks which help tracking down common errors.

ObjectTK does not force you to use its functionality and skip the OpenGL API at all. It is perfectly fine to use the OpenGL API directly and the ObjectTK types side-by-side, because ObjectTK does not explicitly keep track of any OpenGL state which might get corrupted when you call the OpenGL API without it knowing. This is an essential feature which makes ObjectTK very usable even if it is not a "complete" wrapper around every corner of OpenGL.

## What about performance?
Just like any wrapper it introduces another layer between the things you want to get done and the hardware, so it may theoretically slow things down a bit, but there are two things to consider:
- When using modern OpenGL, which is the main target of ObjectTK, the number of API-calls is much lower than it used to be. That means that the overhead of each API-call is not that important anymore.
- The wrapper really is very thin, more often than not there is just a single method call between you and the OpenGL API for functionality which might get used very often. For initialization-related stuff the layer may be a little thicker because it does things right, with all possible error-checking and so forth.

## Examples
For examples please have a look at the Examples project and the wiki pages: [Basic example](https://github.com/JcBernack/ObjectTK/wiki/Basic-example)
