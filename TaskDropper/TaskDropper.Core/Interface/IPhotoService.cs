using MvvmCross.Plugin.PictureChooser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TaskDropper.Core.Interface
{
    public interface IPhotoService
    {
        void ChoosePictureFromGallery(Action<byte[]> action);
        void TakePictureFromCamera(Action<byte[]> action);
    }
}
