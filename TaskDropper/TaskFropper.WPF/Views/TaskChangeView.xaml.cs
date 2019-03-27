using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskDropper.Core.ViewModels;

namespace TaskFropper.WPF.Views
{
    /// <summary>
    /// Interaction logic for TaskChangeView.xaml
    /// </summary>
    /// 
    public partial class TaskChangeView : MvxWpfView<TaskChangedViewModel>
    {
        public TaskChangeView()
        {
            InitializeComponent();
           

            // Create Viewport3D as content of window.
            Viewport3D viewport = new Viewport3D();

            //  Content = viewport;
            Content = viewport;

            // Get the MeshGeometry3D from the GenerateSphere method.
            MeshGeometry3D mesh =
                GenerateSphere(new Point3D(0, 0, 0), 2, 100, 100);
            mesh.Freeze();

            // Define a brush for the sphere.
            Brush[] brushes = new Brush[2] { Brushes.White, Brushes.WhiteSmoke };
            DrawingGroup drawgrp = new DrawingGroup();
            drawgrp.Opacity = 0.75;

            for (int i = 0; i < brushes.Length; i++)
            {
                RectangleGeometry rectgeo =
                    new RectangleGeometry(new Rect(10 * i, 0, 10, 580));

                GeometryDrawing geodraw =
                    new GeometryDrawing(brushes[i], null, rectgeo);

                drawgrp.Children.Add(geodraw);
            }
            DrawingBrush drawbrsh = new DrawingBrush(drawgrp);
            drawbrsh.Freeze();

            // Define the GeometryModel3D.
            GeometryModel3D geomod = new GeometryModel3D();
            geomod.Geometry = mesh;
            geomod.Material = new DiffuseMaterial(drawbrsh);

            // Create a ModelVisual3D for the GeometryModel3D.
            ModelVisual3D modvis = new ModelVisual3D();
            modvis.Content = geomod;
            viewport.Children.Add(modvis);

            // Create another ModelVisual3D for light.
            Model3DGroup modgrp = new Model3DGroup();
            modgrp.Children.Add(new AmbientLight(Color.FromRgb(128, 128, 128)));
            modgrp.Children.Add(
                new DirectionalLight(Color.FromRgb(128, 128, 128),
                                     new Vector3D(2, -3, -1)));

            modvis = new ModelVisual3D();
            modvis.Content = modgrp;
            viewport.Children.Add(modvis);

            // Create the camera.
            PerspectiveCamera cam = new PerspectiveCamera(new Point3D(0, 0, 8),
                            new Vector3D(0, 0, -1), new Vector3D(0, 1, 0), 45);
            viewport.Camera = cam;

            // Create a transform for the GeometryModel3D.
            AxisAngleRotation3D axisangle =
                new AxisAngleRotation3D(new Vector3D(1, 1, 0), 0);
            RotateTransform3D rotate = new RotateTransform3D(axisangle);
            geomod.Transform = rotate;

           // Animate the RotateTransform3D.
           //DoubleAnimation anima =
           //    new DoubleAnimation(360, new Duration(TimeSpan.FromSeconds(5)));
           // anima.RepeatBehavior = RepeatBehavior.Forever;
           // axisangle.BeginAnimation(AxisAngleRotation3D.AngleProperty, anima);
           // Storyboard.SetTargetProperty(anima, new PropertyPath("(0.75)", new DependencyProperty[] { Brush.OpacityProperty }));
        }

        MeshGeometry3D GenerateSphere(Point3D center, double radius,
                                    int slices, int stacks)
        {
            // Create the MeshGeometry3D.
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Fill the Position, Normals, and TextureCoordinates collections.
            for (int stack = 0; stack <= stacks; stack++)
            {
                double phi = Math.PI / 2 - stack * Math.PI / stacks;
                double y = radius * Math.Sin(phi);
                double scale = -radius * Math.Cos(phi);

                for (int slice = 0; slice <= slices; slice++)
                {
                    double theta = slice * 2 * Math.PI / slices;
                    double x = scale * Math.Sin(theta);
                    double z = scale * Math.Cos(theta);

                    Vector3D normal = new Vector3D(x, y, z);
                    mesh.Normals.Add(normal);
                    mesh.Positions.Add(normal + center);
                    mesh.TextureCoordinates.Add(
                            new Point((double)slice / slices,
                                      (double)stack / stacks));

                }
            }

            // Fill the TriangleIndices collection.
            for (int stack = 0; stack < stacks; stack++)
                for (int slice = 0; slice < slices; slice++)
                {
                    int n = slices + 1; // Keep the line length down.

                    if (stack != 0)
                    {
                        mesh.TriangleIndices.Add((stack + 0) * n + slice);
                        mesh.TriangleIndices.Add((stack + 1) * n + slice);
                        mesh.TriangleIndices.Add((stack + 0) * n + slice + 1);
                    }
                    if (stack != stacks - 1)
                    {
                        mesh.TriangleIndices.Add((stack + 0) * n + slice + 1);
                        mesh.TriangleIndices.Add((stack + 1) * n + slice);
                        mesh.TriangleIndices.Add((stack + 1) * n + slice + 1);
                    }
                }
            return mesh;
        }
   
        public TaskChangeView(bool contentLoaded)
        {
            _contentLoaded = contentLoaded;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            slider.Value = e.GetPosition(null).X/2;
        }
    }
}
