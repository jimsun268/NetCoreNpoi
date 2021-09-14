using InfrastructureLibary.ETW;
using Microsoft.Win32;
using NPOI.SS.UserModel;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelNpoiClass
{
    public class NpoiService : INpoiService
    {
        public NpoiService (IETWService eTWService, IDialogService dialogService)
        {
            _eTWService = eTWService;
            _dialogService = dialogService;
            _eTWService.ProcessingStart("ModelNpoiClass.NpoiService");
        }

        #region Fields
        private static DataSet _dataSet;
        private OpenFileDialog _openFile;
        private FileInfo _fileInfo;
        private IETWService _eTWService;
        private IDialogService _dialogService;

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
            if(_openFile ==null)
            {
                _openFile = new OpenFileDialog();
                _openFile.Filter = "XLS (*.xls)|*.xls|XLSX (*.xlsx)|*.xlsx";
            }
            if (_openFile.ShowDialog() == true)
            {
                _fileInfo = new FileInfo(_openFile.FileName);
               if (_fileInfo.Extension== ".xls" || _fileInfo.Extension == ".xlsx")
                {
                    _workBook = WorkbookFactory.Create(_fileInfo.OpenRead());
                    if (_workBook != null)
                    {
                        List<string> vs = new List<string>();
                        for (int i = 0; i < _workBook.NumberOfSheets; i++)
                        {
                            vs.Add(_workBook.GetSheetAt(i).SheetName);
                        }
                        _dialogService.ShowDialog("WarningDialog", new DialogParameters($"message=oper surrect {vs.Count.ToString ()}"), null);
                    }
                }
                else
                {
                    _dialogService.ShowDialog("WarningDialog", new DialogParameters($"message={"请选择EXCEL文件"}"), null);
                }
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
