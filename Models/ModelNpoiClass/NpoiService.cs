using InfrastructureLibary.ETW;
using Microsoft.Win32;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelNpoiClass
{
    public class NpoiService : INpoiService
    {
        public NpoiService (IETWService eTWService)
        {
            eTWService.ProcessingStart("ModelNpoiClass");
            _openFile = new OpenFileDialog();
            _openFile.Filter = "XLS (*.xls)|*.xls|XLSX (*.xlsx)|*.xlsx";
            
        }

        #region Fields
        private static DataSet _dataSet;
        private OpenFileDialog _openFile;
        private string _filePathAndName;
        private IWorkbook _workBook;
        

        #endregion

        #region Properties
        public DataSet DataSet => _dataSet ??= new DataSet();
        public string FileExt
        {
            get
            {
                if (string.IsNullOrEmpty(_filePathAndName)) GetFile();
                return _filePathAndName.Split(".").Last();
            }
        }
        public string FileName
        {
            get
            {
                if (string.IsNullOrEmpty(_filePathAndName)) GetFile();
                return _filePathAndName.Split(@"\").Last().Split(".").First();
            }
        }
        public string FilePath
        {
            get
            {
                if (string.IsNullOrEmpty(_filePathAndName)) GetFile();
                int indx = FileName.Length + FileExt.Length + 1;
                return _filePathAndName.Remove(_filePathAndName.Length - indx, indx);
            }
        }
        #endregion

        #region private Methods
        private void GetFile()
        {
            if (_openFile.ShowDialog() == true)
            {
                _filePathAndName = _openFile.FileName;                
            }

        }
        #endregion

        #region Interface
        public void ShowDialog()
        {
            GetFile();
        }

        #endregion
    }
}
