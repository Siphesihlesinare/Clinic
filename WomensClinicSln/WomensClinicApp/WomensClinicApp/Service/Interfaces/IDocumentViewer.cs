using System;
using System.Collections.Generic;
using System.Text;

namespace WomensClinicApp.Service.Interfaces
{
    public interface IDocumentViewer
    {
        void ViewDocument(string path, string documentName);
    }
}
